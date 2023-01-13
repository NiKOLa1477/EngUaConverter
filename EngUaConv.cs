namespace EngUaConverter
{
    static class EngUaConv
    {
        private static Dictionary<char, char> eng2ua;
        private static Dictionary<char, char> ua2eng;
        private static string convertedLine = string.Empty;       
        private static void FillEng2UaDict(Dictionary<char, char> dict)
        {
            dict.Add('q', 'й');
            dict.Add('w', 'ц');
            dict.Add('e', 'у');
            dict.Add('r', 'к');
            dict.Add('t', 'е');
            dict.Add('y', 'н');
            dict.Add('u', 'г');
            dict.Add('i', 'ш');
            dict.Add('o', 'щ');
            dict.Add('p', 'з');
            dict.Add('[', 'х');
            dict.Add(']', 'ї');
            dict.Add('{', 'Х');
            dict.Add('}', 'Ї');

            dict.Add('a', 'ф');
            dict.Add('s', 'і');
            dict.Add('d', 'в');
            dict.Add('f', 'а');
            dict.Add('g', 'п');
            dict.Add('h', 'р');
            dict.Add('j', 'о');
            dict.Add('k', 'л');
            dict.Add('l', 'д');
            dict.Add(';', 'ж');
            dict.Add('\'', 'є');
            dict.Add('|', '/');
            dict.Add(':', 'Ж');
            dict.Add('"', 'Є');

            dict.Add('z', 'я');
            dict.Add('x', 'ч');
            dict.Add('c', 'с');
            dict.Add('v', 'м');
            dict.Add('b', 'и');
            dict.Add('n', 'т');
            dict.Add('m', 'ь');
            dict.Add(',', 'б');
            dict.Add('.', 'ю');
            dict.Add('/', '.');
            dict.Add('<', 'Б');
            dict.Add('>', 'Ю');
            dict.Add('?', ',');
            
            dict.Add('`', '\'');
            dict.Add('~', '₴');            
            dict.Add('@', '"');
            dict.Add('#', '№');
            dict.Add('$', ';');            
            dict.Add('^', ':');
            dict.Add('&', '?');
        }
        private static void FillUa2EngDict(Dictionary<char, char> dict)
        {
            dict.Add('й', 'q');
            dict.Add('ц', 'w');
            dict.Add('у', 'e');
            dict.Add('к', 'r');
            dict.Add('е', 't');
            dict.Add('н', 'y');
            dict.Add('г', 'u');
            dict.Add('ш', 'i');
            dict.Add('щ', 'o');
            dict.Add('з', 'p');
            dict.Add('х', '[');
            dict.Add('ї', ']');

            dict.Add('Х', '{');
            dict.Add('Ї', '}');

            dict.Add('ф', 'a');
            dict.Add('і', 's');
            dict.Add('в', 'd');
            dict.Add('а', 'f');
            dict.Add('п', 'g');
            dict.Add('р', 'h');
            dict.Add('о', 'j');
            dict.Add('л', 'k');
            dict.Add('д', 'l');
            dict.Add('ж', ';');
            dict.Add('є', '\'');
            dict.Add('/', '|');

            dict.Add('Ж', ':');
            dict.Add('Є', '"');

            dict.Add('я', 'z');
            dict.Add('ч', 'x');
            dict.Add('с', 'c');
            dict.Add('м', 'v');
            dict.Add('и', 'b');
            dict.Add('т', 'n');
            dict.Add('ь', 'm');
            dict.Add('б', ',');
            dict.Add('ю', '.');
            dict.Add('.', '/');
            dict.Add(',', '?');

            dict.Add('Б', '<');
            dict.Add('Ю', '>');
            

            dict.Add('\'', '`');
            dict.Add('₴', '~');
            dict.Add('"', '@');
            dict.Add('№', '#');
            dict.Add(';', '$');
            dict.Add(':', '^');
            dict.Add('?', '&');
        }      
        static EngUaConv() 
        {
            eng2ua = new Dictionary<char, char>();
            ua2eng = new Dictionary<char, char>();
            FillEng2UaDict(eng2ua);
            FillUa2EngDict(ua2eng);             
        }            
        private static void Convert(string line, bool isUa2Eng)
        {
            line ??= string.Empty;
            if (line == string.Empty)
                convertedLine = "No Data! Please enter some text.";
            else
            {
                Dictionary<char, char> dict;
                dict = (isUa2Eng) ? ua2eng : eng2ua;
                string newLine = string.Empty, lowerLine = line.ToLower();
                for (int i = 0; i < line.Length; i++)
                {
                    if(isUa2Eng && (line[i] == 'Х' || line[i] == 'Ї' || line[i] == 'Ж'
                        || line[i] == 'Є' || line[i] == 'Б' || line[i] == 'Ю'))
                    {                      
                            newLine += dict[line[i]];
                    }
                    else if (dict.TryGetValue(lowerLine[i], out char value))
                    {
                        newLine += (lowerLine[i] == line[i]) ? value : value.ToString().ToUpper();
                    }
                    else
                        newLine += line[i];
                }
                convertedLine = newLine;
            }           
        }
        /// <summary>
        /// Convert english garbage line to ukrainian normal one
        /// </summary>
        /// <param name="line">Line to convert</param>
        /// <returns>string convertedLine</returns>
        public static string Eng2Ua(string line)
        {
            Convert(line, isUa2Eng:false);
            return convertedLine;
        }
        /// <summary>
        /// Convert ukrainian garbage line to english normal one
        /// </summary>
        /// <param name="line">Line to convert</param>
        /// <returns>string convertedLine</returns>
        public static string Ua2Eng(string line)
        {
            Convert(line, isUa2Eng: true);
            return convertedLine;
        }
        
    }
}
