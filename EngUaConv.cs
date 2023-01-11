namespace EngUaConverter
{
    public class EngUaConv
    {
        private Dictionary<char, char> dict;        
        private string convertedLine = string.Empty;
        private bool isUa2Eng;
        private void FillEng2UaDict()
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
        private void FillUa2EngDict()
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
        /// <summary>
        /// Creates converter class 
        /// </summary>
        /// <param name="isEng2Ua">if u want to convert from ua2eng - false</param>
        public EngUaConv(bool isEng2Ua = true) 
        { 
            dict = new Dictionary<char, char>();
            isUa2Eng = !isEng2Ua;
            if (isEng2Ua)
                FillEng2UaDict();
            else
                FillUa2EngDict();
             
        }      
        /// <summary>
        /// Converts an english/ukrainian garbage line to ukrainian/english normal line
        /// </summary>
        /// <param name="line">Line to convert from</param>
        public void Convert(string line)
        {
            line ??= string.Empty;
            if (line == string.Empty)
                convertedLine = "No Data! Please enter some text.";
            else
            {
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
        /// Returns converted line
        /// </summary>
        /// <returns>string convertedLine</returns>
        public override string ToString() { return convertedLine; }              
    }
}
