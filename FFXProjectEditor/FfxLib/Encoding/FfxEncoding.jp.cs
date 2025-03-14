﻿using System.Collections.Generic;

namespace FFXProjectEditor.Utils.Encoding
{
    public partial class FfxEncoding
    {
        public static readonly Dictionary<byte, char> JpDecoder = new Dictionary<byte, char>
        {
            { 48, '0' },
            { 49, '1' },
            { 50, '2' },
            { 51, '3' },
            { 52, '4' },
            { 53, '5' },
            { 54, '6' },
            { 55, '7' },
            { 56, '8' },
            { 57, '9' },
            { 58, ' ' },
            { 59, '!' },
            { 60, 'ー' },
            { 61, '~' },
            { 62, '…' },
            { 63, '%' },
            { 64, '&' },
            { 65, '×' },
            { 66, '(' },
            { 67, ')' },
            { 68, '*' },
            { 69, '+' },
            { 70, ',' },
            { 71, '–' },
            { 72, '.' },
            { 73, '/' },
            { 74, ':' },
            { 75, ';' },
            { 76, '【' },
            { 77, '=' },
            { 78, '】' },
            { 79, '?' },
            { 80, 'X' },
            { 81, '。' },
            { 82, '「' },
            { 83, '」' },
            { 84, '、' },
            { 85, '·' },
            { 86, '『' },
            { 87, '』' },
            { 88, 'α' },
            { 89, '”' },
            { 90, '⑯' },
            { 91, '⑰' },
            { 92, ' ' }, // Dupe
            { 93, ' ' }, // Dupe
            { 94, ' ' }, // Dupe
            { 95, 'ぁ' },
            { 96, 'あ' },
            { 97, 'ぃ' },
            { 98, 'い' },
            { 99, 'ぅ' },
            { 100, 'う' },
            { 101, 'ぇ' },
            { 102, 'え' },
            { 103, 'ぉ' },
            { 104, 'お' },
            { 105, 'か' },
            { 106, 'が' },
            { 107, 'き' },
            { 108, 'ぎ' },
            { 109, 'く' },
            { 110, 'ぐ' },
            { 111, 'け' },
            { 112, 'げ' },
            { 113, 'こ' },
            { 114, 'ご' },
            { 115, 'さ' },
            { 116, 'ざ' },
            { 117, 'し' },
            { 118, 'じ' },
            { 119, 'す' },
            { 120, 'ず' },
            { 121, 'せ' },
            { 122, 'ぜ' },
            { 123, 'そ' },
            { 124, 'ぞ' },
            { 125, 'た' },
            { 126, 'だ' },
            { 127, 'ち' },
            { 128, 'ぢ' },
            { 129, 'っ' },
            { 130, 'つ' },
            { 131, 'づ' },
            { 132, 'て' },
            { 133, 'で' },
            { 134, 'と' },
            { 135, 'ど' },
            { 136, 'な' },
            { 137, 'に' },
            { 138, 'ね' },
            { 139, 'ぬ' },
            { 140, 'の' },
            { 141, 'は' },
            { 142, 'ば' },
            { 143, 'ぱ' },
            { 144, 'ひ' },
            { 145, 'び' },
            { 146, 'ぴ' },
            { 147, 'ふ' },
            { 148, 'ぶ' },
            { 149, 'ぷ' },
            { 150, 'へ' },
            { 151, 'べ' },
            { 152, 'ぺ' },
            { 153, 'ほ' },
            { 154, 'ぼ' },
            { 155, 'ぽ' },
            { 156, 'ま' },
            { 157, 'み' },
            { 158, 'む' },
            { 159, 'め' },
            { 160, 'も' },
            { 161, 'ゃ' },
            { 162, 'や' },
            { 163, 'ゅ' },
            { 164, 'ゆ' },
            { 165, 'ょ' },
            { 166, 'よ' },
            { 167, 'ら' },
            { 168, 'り' },
            { 169, 'る' },
            { 170, 'れ' },
            { 171, 'ろ' },
            { 172, 'わ' },
            { 173, 'を' },
            { 174, 'ん' },
            { 175, 'ァ' },
            { 176, 'ア' },
            { 177, 'ィ' },
            { 178, 'イ' },
            { 179, 'ゥ' },
            { 180, 'ウ' },
            { 181, 'ェ' },
            { 182, 'エ' },
            { 183, 'ォ' },
            { 184, 'オ' },
            { 185, 'カ' },
            { 186, 'ガ' },
            { 187, 'キ' },
            { 188, 'ギ' },
            { 189, 'ク' },
            { 190, 'グ' },
            { 191, 'ケ' },
            { 192, 'ゲ' },
            { 193, 'コ' },
            { 194, 'ゴ' },
            { 195, 'サ' },
            { 196, 'ザ' },
            { 197, 'シ' },
            { 198, 'ジ' },
            { 199, 'ス' },
            { 200, 'ズ' },
            { 201, 'セ' },
            { 202, 'ゼ' },
            { 203, 'ソ' },
            { 204, 'ゾ' },
            { 205, 'タ' },
            { 206, 'ダ' },
            { 207, 'チ' },
            { 208, 'ヂ' },
            { 209, 'ッ' },
            { 210, 'ツ' },
            { 211, 'ヅ' },
            { 212, 'テ' },
            { 213, 'デ' },
            { 214, 'ト' },
            { 215, 'ド' },
            { 216, 'ナ' },
            { 217, 'ニ' },
            { 218, 'ヌ' },
            { 219, 'ネ' },
            { 220, 'ノ' },
            { 221, 'ハ' },
            { 222, 'バ' },
            { 223, 'パ' },
            { 224, 'ヒ' },
            { 225, 'ビ' },
            { 226, 'ピ' },
            { 227, 'フ' },
            { 228, 'ブ' },
            { 229, 'プ' },
            { 230, 'ヘ' },
            { 231, 'ベ' },
            { 232, 'ペ' },
            { 233, 'ホ' },
            { 234, 'ボ' },
            { 235, 'ポ' },
            { 236, 'マ' },
            { 237, 'ミ' },
            { 238, 'ム' },
            { 239, 'メ' },
            { 240, 'モ' },
            { 241, 'ャ' },
            { 242, 'ヤ' },
            { 243, 'ュ' },
            { 244, 'ユ' },
            { 245, 'ョ' },
            { 246, 'ヨ' },
            { 247, 'ラ' },
            { 248, 'リ' },
            { 249, 'ル' },
            { 250, 'レ' },
            { 251, 'ロ' },
            { 252, 'ワ' },
            { 253, 'ヲ' },
            { 254, 'ン' },
            { 255, 'ヴ' },
        };
    }
}
