using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace ZeucBackend.IntegrationTests
{
    [CollectionDefinition("Non-Parallel Collection", DisableParallelization = true)]
    public class CategoryAndSiteIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CategoryAndSiteIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddAndGetCategory()
        {
            await _client.PostAsJsonAsync("/api/category",
                new
                {
                    name = "Peryferia",
                    link = "peripherals",
                    subcategories = new List<object> {
                    new {
                        name = "Klawiatury",
                        link = "keyboard",
                        description = "Trzeszczące, łatwo brudzące urządzenia, zawsze w zasięgu ręki każdego komputerowego świra. Poniżej znajdziesz najlepsze nasze produkty, abyś chociaż przynajmniej miał wrażenie, że się staraliśmy."
                    },
                    new {
                        name = "Myszki",
                        link = "mouse",
                        description = "Swoją nazwę zawdzięczają niesławnemu zwierzęciu, kojarzącego się z obrzydlistwem. Poniżej wszystkie nasze produkty tego typu, bleh..."
                    },
                    new {
                        name = "Drukarki",
                        link = "printers",
                        description = "Urządzenia, obsługujące wymarłą technologię informatyczną, opierającą się na brudzeniu płynną substancją kawałka drewna. Poniżej znajdziesz parę naszych rozwiązań tej \"technologii\"."
                    },
                    new {
                        name = "Skanery",
                        link = "scanners",
                        description = "Wraz z drukarką tworzą zespół wejścia/wyjścia dla technologii zapisu danych na drzewie. Poniżej znajdziesz idealne urządzenia do swojego repertuaru robotów drzewnych."
                    },
                    new {
                        name = "Monitory",
                        link = "monitors",
                        description = "Świecą w oczy z różną intensywnością, zależną od wyjścia twojego komputera. Poniżej znajdują się same perły od naszych dostawców tego typu sprzętu."
                    }
                    }
                }
            );

            var response = await _client.GetAsync("/api/category");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response content:");
            Console.WriteLine(content);
            Assert.Contains("Peryferia", content);
        }

        [Fact]
        public async Task AddItemAndGetItem()
        {
            await _client.PostAsJsonAsync("/api/items",
                new
                {
                    name = "ZEUC Keyboard Pro Extra",
                    link = "zeuc-keyboard-pro-extra",
                    description = "Extra keyboard for extra users.",
                    price = 299.99,
                    ImageUrl = "/keyboard.png",
                    subcategoryId = 1,
                    metadata = new Dictionary<string, object> {
                    { "number_of_buttons", 164 },
                    { "layout", "US" }
                    }
                }
            );

            var response = await _client.GetAsync("/api/items");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("ZEUC", content);
        }

        [Fact]
        public async Task GetItemSite()
        {
            var response = await _client.GetAsync("/api/sites/peripherals/keyboard");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response content:");
            Console.WriteLine(content);
            Assert.Contains("ZEUC", content);
        }
    }
}