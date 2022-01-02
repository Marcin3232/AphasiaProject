using System.IO;
using ExerciseResource.Helpers;

namespace ExerciseResource.Models.Exercise24
{
    // Resource oznacza całą KATEGORIĘ
    public struct Exercise24Resource
    {
        public string CategoryName { get; set; }
        public MemoryCard[] Cards { get; set; }

        public static Exercise24Resource CreateExercise24Resource(string categoryPath)
        {
            Exercise24Resource resource = new Exercise24Resource();

            resource.CategoryName = Path.GetFileName(categoryPath);

            string[] imgPaths = Directory.GetFiles(categoryPath);

            string[] srcs = SourceHelper.GetSource(imgPaths);

            resource.Cards = MemoryCard.MakeCardsArray(srcs);

            return resource;
        }
    }
    public struct MemoryCard
    {
        public string ImgSrc { get; private set; }
        public int ID { get; set; }

        public static MemoryCard[] MakeCardsArray(string[] srcs)
        {
            var cards = new MemoryCard[srcs.Length];

            for (int i = 0; i < srcs.Length; i++)
            {
                cards[i].ImgSrc = srcs[i];
                cards[i].ID = i;
            }

            return cards;
        }
    }
}

