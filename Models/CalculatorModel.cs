namespace webLab2._1.Models
{
    public class CalculatorModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Operation { get; set; }

        public string Calc()
        {
            return Operation switch
            {
                "+" => $"{X} + {Y} = {X + Y}",
                "-" => $"{X} - {Y} = {X - Y}",
                "*" => $"{X} * {Y} = {X * Y}",
                "/" when Y != 0 => $"{X} / {Y} = {X / Y}",
                "/" when Y == 0 => "zero division error!!!!!",
                _ => "Invalid operation"
            };
        }
    }
}
