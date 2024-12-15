using boundingBoxProblem.DataModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace boundingBoxProblem.Business
{
    public static class boundBoxBusiness
    {

        public static List<string> boundBoxHandler(IEnumerable<wordsBoundBoxDataModel> boundBoxlist)
        {
            try
            {



                List<string> result = new List<string>();

                StringBuilder tempString = new StringBuilder(); ;

                var boxGroupperBYLine = boundBoxlist.GroupBy(w => w.bbox.y)
                                                    .Select(x => x.OrderBy(w => w.bbox.x))
                                                    .ToList();

                double maxHeight = 15; //Assumed  because haven't any reply from HR

                int numberOfLines = 0;

                foreach (var line in boxGroupperBYLine)
                {
                    var lineList = line.ToList();
                    for (int i = 0; i < line.Count(); i++)
                    {
                        tempString.Append(lineList[i].word);
                        if (i != line.Count() - 1) // to add white spaces between words
                        {
                            tempString.Append(new string(' ', lineList[i + 1].bbox.x - tempString.Length));
                        }
                        if (lineList[i].bbox.height > maxHeight) // to determine what is the height for line
                        {
                            numberOfLines = (int)Math.Ceiling(lineList[i].bbox.height / maxHeight);
                        }
                    }
                    result.Add(tempString.ToString());
                    for (int i = 0; i < numberOfLines - 1; i++) //if word height take more than one line set the number ofline empty
                    {
                        result.Add(string.Empty);
                    }
                    numberOfLines = 0;
                    tempString.Clear();
                }



                return result;
            }
            catch (Exception ex)
            {
                throw ;
            }

        }

    }

}
