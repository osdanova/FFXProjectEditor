using System;
using System.Collections.Generic;
using System.Linq;

namespace FFXProjectEditor.Utils.Encoding
{
    public partial class FfxEncoding
    {
        /*
         * Decode the given byte array into a text script
         */
        public static TextScript DecodeScript(byte[] byteScript)
        {
            TextScript textScript = new();

            TextScript.TextCommand currentCommand = new();
            List<byte> currentArray = new();
            for (int i = 0; i < byteScript.Length; i++)
            {
                byte b = byteScript[i];

                // String
                if (!ControlDecoder.ContainsKey(b))
                {
                    currentArray.Add(b);
                }
                // Control Code
                else
                {
                    // Save string if any
                    if (currentArray.Count > 0)
                    {
                        currentCommand.ByteArray = currentArray.ToArray();
                        textScript.Commands.Add(currentCommand);
                    }

                    // Add code
                    currentCommand = new();
                    currentCommand.ControlCode = b;
                    if(b == C_FORMAT || b == C_CHAR_NAME) // 1 byte param
                    {
                        currentCommand.ByteArray = [byteScript[i + 1]];
                        i++;
                    }
                    textScript.Commands.Add(currentCommand);

                    // Prepare next command
                    currentCommand = new();
                    currentArray = new();
                }
            }

            // Save string if any
            if (currentArray.Count > 0)
            {
                currentCommand.ByteArray = currentArray.ToArray();
                textScript.Commands.Add(currentCommand);
            }


            return textScript;
        }


        /*
         * Decode the given string command
         */
        public static string DecodeString(TextScript.TextCommand stringCommand, Dictionary<byte, char> decoder)
        {
            if (decoder == null)
                throw new Exception("FfxEncoding.DecodeString: Must add a decoder to be used");

            if(stringCommand.IsControlCode)
                throw new Exception("FfxEncoding.DecodeString: This is a control code");

            string finalString = "";
            foreach (byte b in stringCommand.ByteArray)
            {
                if (decoder.ContainsKey(b)) {
                    finalString += decoder[b];
                }
                else {
                    finalString += "<MISS:" + b + ">"; // Using this until the full encodings are known
                    //throw new Exception("FfxEncoding.DecodeString: Invalid byte for given encoder: " + b);
                }
            }
            return finalString;
        }

        /*
         * Encode the given string
         */
        public static TextScript.TextCommand EncodeString(String stringText, Dictionary<char, byte> encoder)
        {
            if (encoder == null)
                throw new Exception("FfxEncoding.DecodeString: Must add a decoder to be used");

            if (stringText == null)
                throw new Exception("FfxEncoding.DecodeString: This is a control code");

            TextScript.TextCommand textCommand = new();
            List<byte> byteArray = new();
            foreach (char c in stringText)
            {
                if (encoder.ContainsKey(c)) {
                    byteArray.Add(encoder[c]);
                }
                else {
                    throw new Exception("FfxEncoding.EncodeString: Invalid char for given encoder: " + c);
                }
            }
            textCommand.ByteArray = byteArray.ToArray();

            return textCommand;
        }

        /*
         * Given a text file it finds and returns the script (as a byte array) located at the given offset
         */
        public static byte[] GetScriptBytesFromTextFile(byte[] textFile, int scriptOffset)
        {
            int endIndex = scriptOffset;
            while (endIndex < textFile.Length && textFile[endIndex] != 0) {
                endIndex++;
            }
            int length = endIndex - scriptOffset;
            byte[] result = new byte[length];
            Array.Copy(textFile, scriptOffset, result, 0, length);

            return result;
        }

        /*
         * Given a text file it inserts the given bytes including the trailing NULL
         */
        public static byte[] WriteBytesIntoTextFile(byte[] textFile, byte[] bytesToWrite)
        {
            // Add NULL byte (0)
            byte[] bytesToWriteExtended = new byte[bytesToWrite.Length + 1];
            Array.Copy(bytesToWrite, bytesToWriteExtended, bytesToWrite.Length);

            return textFile.Concat(bytesToWriteExtended).ToArray();
        }

        /*
         * A text script contains the commands that form a text.
         * A script contains a list of commands which can be either simple text or a control code with a parameter
         */
        public class TextScript
        {
            public List<TextCommand> Commands = new();

            public TextScript()
            {
                Commands = new();
            }

            // Can be a string or a control code with parameters
            public class TextCommand
            {
                public byte ControlCode { get; set; }
                public byte[] ByteArray { get; set; }

                public bool IsControlCode => ControlCode != 0;
            }

            public string GetString(Dictionary<byte, char> decoder, bool withControlCodes = false)
            {
                if (decoder == null)
                    throw new Exception("TextScript.GetString: Must add a decoder to be used");

                string result = "";
                foreach (TextCommand command in Commands)
                {
                    if (!command.IsControlCode)
                    {
                        result += DecodeString(command, decoder);
                    }
                    else
                    {
                        if (!withControlCodes && command.ControlCode == C_FORMAT) {
                            continue;
                        }

                        switch(command.ControlCode)
                        {
                            case C_NEW_LINE:
                                result += Environment.NewLine;
                                break;

                            case C_FORMAT:
                                if (FormatCodes.ContainsKey(command.ByteArray[0])) {
                                    result += FormatCodes[command.ByteArray[0]];
                                }
                                else {
                                    result += "<C_ERROR:" + command.ControlCode + ":" + command.ByteArray[0] + ">";
                                }
                                break;

                            case C_CHAR_NAME:
                                if (CharacterNameCodes.ContainsKey(command.ByteArray[0])) {
                                    result += CharacterNameCodes[command.ByteArray[0]];
                                }
                                else {
                                    result += "<C_ERROR:" + command.ControlCode + ":" + command.ByteArray[0] + ">";
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }

                return result;
            }
        }
    }
}
