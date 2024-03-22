using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestSearchWord
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string stimulus =
                "15\n" +
                "KOKODPEOTOTULCI\n" +
                "QAEOXQGBPYZWEFB\n" +
                "RWLRDBBLMFBAVWM\n" +
                "DLTIUCSIBAESGLA\n" +
                "YWKAXAURQSRASAB\n" +
                "XXUEPCMPUARAYSO\n" +
                "GJURRSPOFFCHHSH\n" +
                "HRIQWMMQIOKOWII\n" +
                "ELUALYIEOTLABEQ\n" +
                "DGJMEKLTDEDPMUD\n" +
                "WAFKPDTILIKUMAN\n" +
                "IKCEZYHVWEHTCHH\n" +
                "GITCDZCYZEAQPPC\n" +
                "MAUNGPJAKQCEMOC\n" +
                "BLZRPXBLTKPMASJ\n" +
                "April Balto Bambi Dolly Garfield GrumpyCat Ham Harambe Hedwig Jaws Kermit Koko Laika Lassie MickeyMouse Seabiscuit Tilikum Toto\n";
            using (StringWriter sw = new StringWriter())
            {
                //Console.SetOut(sw);                         // console out set to stringwriter
                Console.SetIn(new StringReader(stimulus));  // console input set to stimulus
                SearchWordApp.Main(new string[] { });       // calling Main() - empty Args
                string output = sw.ToString().Trim();       // get output from stringwriter
                //Assert.AreEqual("Expected output", output); // expected output
            }
        }
    }
}
