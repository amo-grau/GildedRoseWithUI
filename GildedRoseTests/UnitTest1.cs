using FlaUI.Core;

namespace GildedRoseTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var app = Application.Launch("C:\\Users\\15osc\\source\\repos\\GildedRose\\GuildedRose\\bin\\Debug\\net8.0-windows\\GuildedRoseUI.exe");
            Thread.Sleep(3000);
            app.Close();
        }
    }
}