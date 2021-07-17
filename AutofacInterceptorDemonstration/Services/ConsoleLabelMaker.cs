using System;
using System.Linq;
using System.Text;

namespace AutofacInterceptorDemonstration.Services
{
    public class ConsoleLabelMaker : ILabelMaker
    {
        /// <summary>
        /// Prints the specified text onto a label on the Console.
        /// </summary>
        /// <param name="contents">The contents to be printed.</param>
        public virtual void Print(string contents)
        {
            var dimensions = CalculateLabelSize(contents);

            var contentLines = contents.Split(Environment.NewLine);

            var sb = new StringBuilder();
            sb.AppendLine($"+{new string('-', dimensions.width - 2)}+");

            foreach (var line in contentLines)
                sb.AppendLine($"| {line.PadRight(dimensions.width - 4)} |");

            sb.AppendLine($"+{new string('-', dimensions.width - 2)}+");

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Calculates the estimated width and height of the label in the console.
        /// </summary>
        /// <param name="contents">The contents that would be printed.</param>
        /// <returns>The width and height estimation for the label.</returns>
        public virtual (int width, int height) CalculateLabelSize(string contents)
        {
            var contentLines = contents.Split(Environment.NewLine);

            var width = contentLines.Max(x => x.Length) + 4;
            var height = contentLines.Length + 2;

            return (width, height);
        }
    }
}