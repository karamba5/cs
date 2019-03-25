namespace Lab1._2
{
    public static class Base64
    {
        
        private static int _length, _length2;
        private static int _blockCount;
        private static int _paddingCount;

        private static byte[] ToArrayBytes(byte[] input)
        {
            byte[] source = input;
            _length = input.Length;
            if ((_length % 3) == 0)
            {
                _paddingCount = 0;
                _blockCount = _length / 3;
            }
            else
            {
                _paddingCount = 3 - (_length % 3);
                _blockCount = (_length + _paddingCount) / 3;
            }
            _length2 = _length + _paddingCount;

            return source;
        }

        public static char[] GetEncoded(byte[] input)
        {
            byte[] source = ToArrayBytes(input);
            byte[] source2;
            source2 = new byte[_length2];
            
            for (int x = 0; x < _length2; x++)
            {
                if (x < _length)
                {
                    source2[x] = source[x];
                }
                else
                {
                    source2[x] = 0;
                }
            }

            byte[] buffer = new byte[_blockCount * 4];
            char[] result = new char[_blockCount * 4];
            for (int x = 0; x < _blockCount; x++)
            {
                var b1 = source2[x * 3];
                var b2 = source2[x * 3 + 1];
                var b3 = source2[x * 3 + 2];

                var temp1 = (byte)((b1 & 252) >> 2);

                var temp = (byte)((b1 & 3) << 4);
                var temp2 = (byte)((b2 & 240) >> 4);
                temp2 += temp; //second

                temp = (byte)((b2 & 15) << 2);
                var temp3 = (byte)((b3 & 192) >> 6);
                temp3 += temp; //third

                var temp4 = (byte)(b3 & 63);

                buffer[x * 4] = temp1;
                buffer[x * 4 + 1] = temp2;
                buffer[x * 4 + 2] = temp3;
                buffer[x * 4 + 3] = temp4;

            }

            for (int x = 0; x < _blockCount * 4; x++)
            {
                result[x] = SixBitToChar(buffer[x]);
            }

            switch (_paddingCount)
            {
                case 0: break;
                case 1: result[_blockCount * 4 - 1] = '='; break;
                case 2:
                    result[_blockCount * 4 - 1] = '=';
                    result[_blockCount * 4 - 2] = '=';
                    break;
            }
            return result;
        }

        private static char SixBitToChar(byte b)
        {
            char[] lookupTable = new char[]
                {  'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'};

            if (b <= 63)
            {
                return lookupTable[b];
            }
            else
            {
                return ' ';
            }
        }

    }
}
