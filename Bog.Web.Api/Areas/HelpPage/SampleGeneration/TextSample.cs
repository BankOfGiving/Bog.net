namespace Bog.Web.Api.Areas.HelpPage
{
    using System;

    /// <summary>
    ///     This represents a preformatted text sample on the help page. There's a display template named TextSample associated
    ///     with this class.
    /// </summary>
    public class TextSample
    {
        #region Constructors and Destructors

        public TextSample(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            this.Text = text;
        }

        #endregion

        #region Public Properties

        public string Text { get; private set; }

        #endregion

        #region Public Methods and Operators

        public override bool Equals(object obj)
        {
            TextSample other = obj as TextSample;
            return other != null && this.Text == other.Text;
        }

        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }

        public override string ToString()
        {
            return this.Text;
        }

        #endregion
    }
}