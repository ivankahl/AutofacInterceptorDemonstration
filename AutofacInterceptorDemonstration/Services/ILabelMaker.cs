namespace AutofacInterceptorDemonstration.Services
{
    public interface ILabelMaker
    {
        /// <summary>
        /// Prints the specified string contents on a label.
        /// </summary>
        /// <param name="contents">The contents to be printed.</param>
        void Print(string contents);

        /// <summary>
        /// Calculates the estimated label dimensions.
        /// </summary>
        /// <param name="contents">The contents that will be printed on the label.</param>
        /// <returns>The estimated dimensions of the label.</returns>
        (int width, int height) CalculateLabelSize(string contents);
    }
}