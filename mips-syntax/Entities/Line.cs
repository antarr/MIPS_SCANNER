namespace mips_syntax.Entities
{
    public class Line
    {
        public string Instruction;
        public string Comment;

        public Line(string s)
        {
            var temp = s.Split(new char[]{'#'});
            Instruction = temp[0];
            if (temp.Length > 1)
                Comment = temp[1];
        }
    }
}
