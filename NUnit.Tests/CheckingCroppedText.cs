using LoginApp.NewsViewModel;
using NUnit.Framework;
using System;

namespace NUnit.Tests
{
    [TestFixture]
    class CheckingCroppedText
    {

        [TestCase("*&^%1234as sdfghjt 456sdfgs ghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst tghjkmn dewsd fghjbvc dsrtyh65bwewrgf"
            , "*&^%1234as sdfghjt 456sdfgs ghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst tghjkmn dewsd fghjbvc...", TestName = "1")]

        [TestCase("*&^%1234as sdfghjt 456sdfgs ghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst"
            , "*&^%1234as sdfghjt 456sdfgs ghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst", TestName = "2")]

        [TestCase("*&^%1234assdfghjt456sdfgsghtrdaqwd43fgc3ga6gfdsvbsathjklfdsttghjkmndewsdfghjbvcdsrtyh65bwewrgfaasasdasdasdasdasdasd"
            , "...", TestName = "3")]

        [TestCase("*&^%1234assdfghjt456sdfgsghtrdaqwd43f"
            , "*&^%1234assdfghjt456sdfgsghtrdaqwd43f", TestName = "4")]

        [TestCase("*&^%1234assdfghjt456sdfgsghtrdaqwd43fgc3ga6gfdsvbsathjklfdsttghjkmndewsd fghjbvcdsrtyh65bwewrgfasdasdasdfgdfg"
            , "*&^%1234assdfghjt456sdfgsghtrdaqwd43fgc3ga6gfdsvbsathjklfdsttghjkmndewsd...", TestName = "5")]

        [TestCase("*&^%1234assdfghjt456sdfgsghtrdaqwd43 fgc 3ga 6gfdsvb sathjkl fdst tghjkmn dewsd fghjbvc dsrtyh65bwewrgf"
            , "*&^%1234assdfghjt456sdfgsghtrdaqwd43 fgc 3ga 6gfdsvb sathjkl fdst tghjkmn dewsd fghjbvc...", TestName = "6")]

        [TestCase("*&^%1234assdfghjt456sdfgsghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst"
            , "*&^%1234assdfghjt456sdfgsghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst", TestName = "7")]

        [TestCase("*&^%1234assdfghjt456sdfgsghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst tghjkmndewsdfghjbvcdsrtyh65bwewrgf"
            , "*&^%1234assdfghjt456sdfgsghtrd aqwd 43 fgc 3ga 6gfdsvb sathjkl fdst...", TestName = "8")]

        [TestCase("*&^%1234as sdfghjt 456sdfgsghtrdaqwd43 fgc 3ga 6gfdsvb sathjkl fdst"
            , "*&^%1234as sdfghjt 456sdfgsghtrdaqwd43 fgc 3ga 6gfdsvb sathjkl fdst", TestName = "9")]

        [TestCase(" *&^%1234assdfghjt456sdfgsghtrdaqwd43fgc3ga6gfdsvbsathjklfdst1234assdfghjt456sdfgsghtrdaqwd43fgc3ga6gfdsvbsathjklfdst"
            , "...", TestName = "10")]


        public void TestGetCroppedText(string value, string expAnswer)
        {
            string valueAnswer = CroppText.GetCroppedText(value, 99);

            Assert.AreEqual(expAnswer, valueAnswer);
        }


        [TestCase(null, TestName = "11")]

        public void TestGetCroppedTextException(string value)
        {

            Assert.Throws<NullReferenceException>(() => CroppText.GetCroppedText(value, 99));
        }

    }
}
