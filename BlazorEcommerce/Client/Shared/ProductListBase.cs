namespace BlazorEcommerce.Client.Shared
{
    using BlazorEcommerce.Shared.Models;
    using Microsoft.AspNetCore.Components;

    public class ProductListBase : ComponentBase
    {
        public List<Product> Products { get; set; } = new List<Product>();

        protected override void OnInitialized()
        {
            Products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Title = "The Man in the High Castle",
                    Description = "The Man in the High Castle (1962), by Philip K. Dick, is an alternative history novel wherein the Axis Powers won World War II. The story occurs in 1962, fifteen years after the end of the war in 1947, and depicts the political intrigues between Imperial Japan and Nazi Germany as they rule the partitioned United States. The titular character is the author of a novel-within-the-novel entitled The Grasshopper Lies Heavy, itself also an alternative history of the war.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/87/Man_in_the_High_Castle_%281st_Edition%29.png",
                    Price = 9.99m
                },
                new Product()
                {
                    Id = 2,
                    Title = "The Lost Daughter",
                    Description = "The Lost Daughter is a 2021 psychological drama film adapted for the screen and directed by Maggie Gyllenhaal (in her feature directorial debut) based on the 2006 novel of the same name by Elena Ferrante. The film stars Olivia Colman, Dakota Johnson, Jessie Buckley, Paul Mescal, Dagmara Domińczyk, Jack Farthing, Oliver Jackson-Cohen, with Peter Sarsgaard, and Ed Harris. Colman also serves as an executive producer.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0b/The_Lost_Daughter_%28film%29.jpg",
                    Price = 1.59m
                },
                new Product()
                {
                    Id = 3,
                    Title = "The Terminal List",
                    Description = "The Terminal List is an American action thriller television series based on Jack Carr's 2018 novel of the same name.[1] The series tells the story of a Navy SEAL who seeks to avenge the murder of his family. It stars Chris Pratt (who also serves as an executive producer), Constance Wu, Taylor Kitsch, Riley Keough, Arlo Mertz, and Jeanne Tripplehorn.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/ed/The_Terminal_List.jpeg",
                    Price = 4.99m
                }

            };
        }
    }
}