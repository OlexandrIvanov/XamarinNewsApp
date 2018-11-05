using LoginApp;
using NUnit.Framework;
using System;

namespace NUnit.Tests
{
    [TestFixture]
    public class LoginAndPasswordFildsTests
    {
        [TestCase("Name", false, TestName = "1")]
        [TestCase("MyFirstname", true, TestName = "2")]
        [TestCase("myfirstname", true, TestName = "3")]
        [TestCase("MYFIRSTNAME", true, TestName = "4")]
        [TestCase("MYFIRSTNAME ", false, TestName = "5")]
        [TestCase(" MYFIRSTNAME", false, TestName = "6")]
        [TestCase("MYFIRST NAME", false, TestName = "7")]
        [TestCase("MyFirstname ", false, TestName = "8")]
        [TestCase(" MyFirstname", false, TestName = "9")]
        [TestCase("MyFirs tname", false, TestName = "10")]
        [TestCase("123", false, TestName = "11")]
        [TestCase("12345678", false, TestName = "12")]
        [TestCase("", false, TestName = "13")]
        [TestCase(" ", false, TestName = "14")]
        [TestCase("           ", false, TestName = "15")]
        [TestCase(" 1234567", false, TestName = "16")]
        [TestCase("1234567 ", false, TestName = "17")]
        [TestCase("123 ", false, TestName = "18")]
        [TestCase(" 123", false, TestName = "19")]
        [TestCase("1234 567", false, TestName = "20")]
        [TestCase("4 5", false, TestName = "21")]
        [TestCase("_@#$ ", false, TestName = "22")]
        [TestCase(" _@#$", false, TestName = "23")]
        [TestCase("_@ #$", false, TestName = "24")]
        [TestCase("_@#$$##% ", false, TestName = "25")]
        [TestCase(" _@#$$##%", false, TestName = "26")]
        [TestCase("_@#$$##%", false, TestName = "27")]
        [TestCase("MYFIR99STNAME", false, TestName = "55")]
        [TestCase("55MYFIRSTNAME", false, TestName = "56")]
        [TestCase("MYFIR99STNAME66", false, TestName = "57")]
        [TestCase("myfirs99tname", false, TestName = "58")]
        [TestCase("55myfirstname", false, TestName = "59")]
        [TestCase("myfirstname66", false, TestName = "61")]
        [TestCase("asdasdasd#@$", false, TestName = "62")]
        [TestCase("asd123$%^^", false, TestName = "63")]
        [TestCase("asd*&^%", false, TestName = "64")]
        [TestCase("*&^%1234", false, TestName = "66")]

        public void TestLoginFild(string login, bool expLoginCheckAnswer)
        {
            bool loginAnswer = FieldValidation.CheckLogin(login);

            Assert.AreEqual(expLoginCheckAnswer, loginAnswer);
        }

        [TestCase(null, false, TestName = "80")]

        public void TestLoginFildException(string login, bool expLoginCheckAnswer) {

            Assert.Throws<ArgumentNullException>(() => FieldValidation.CheckLogin(login));
        }

        [TestCase("Name", false, TestName = "28")]
        [TestCase("MyFirstname", true, TestName = "29")]
        [TestCase("myfirstname", true, TestName = "30")]
        [TestCase("MYFIRSTNAME", true, TestName = "31")]
        [TestCase("MYFIRSTNAME ", false, TestName = "32")]
        [TestCase(" MYFIRSTNAME", false, TestName = "33")]
        [TestCase("MYFIRST NAME", false, TestName = "34")]
        [TestCase("MyFirstname ", false, TestName = "35")]
        [TestCase(" MyFirstname", false, TestName = "36")]
        [TestCase("MyFirs tname", false, TestName = "37")]
        [TestCase("123", false, TestName = "38")]
        [TestCase("12345678", true, TestName = "39")]
        [TestCase("", false, TestName = "40")]
        [TestCase(" ", false, TestName = "41")]
        [TestCase("           ", false, TestName = "42")]
        [TestCase(" 1234567", false, TestName = "43")]
        [TestCase("1234567 ", false, TestName = "44")]
        [TestCase("123 ", false, TestName = "45")]
        [TestCase(" 123", false, TestName = "46")]
        [TestCase("1234 567", false, TestName = "47")]
        [TestCase("4 5", false, TestName = "48")]
        [TestCase("_@#$ ", false, TestName = "49")]
        [TestCase(" _@#$", false, TestName = "50")]
        [TestCase("_@ #$", false, TestName = "51")]
        [TestCase("_@#$$##% ", false, TestName = "52")]
        [TestCase(" _@#$$##%", false, TestName = "53")]
        [TestCase("_@#$$##%", true, TestName = "54")]
        [TestCase("MYFIR99STNAME", true, TestName = "67")]
        [TestCase("55MYFIRSTNAME", true, TestName = "68")]
        [TestCase("MYFIR99STNAME66", true, TestName = "69")]
        [TestCase("myfirs99tname", true, TestName = "70")]
        [TestCase("55myfirstname", true, TestName = "71")]
        [TestCase("myfirstname66", true, TestName = "72")]
        [TestCase("asdasdasd#@$", true, TestName = "73")]
        [TestCase("asd123$%^^", true, TestName = "74")]
        [TestCase("asd*&^%", true, TestName = "75")]
        [TestCase("*&^%1234", true, TestName = "76")]
        [TestCase("* 1", false, TestName = "77")]
        [TestCase("* 1 f", false, TestName = "78")]

        public void TestPasswordFild(string password, bool expPasswordCheckAnswer)
        {
            bool passwordAnswer = FieldValidation.CheckPassword(password);

            Assert.AreEqual(expPasswordCheckAnswer, passwordAnswer);
        }

        [TestCase(null, false, TestName = "79")]

        public void TestPasswordFildException(string password, bool expPasswordCheckAnswer)
        {
            Assert.Throws<ArgumentNullException>(() => FieldValidation.CheckPassword(password));
        }

    }
}
