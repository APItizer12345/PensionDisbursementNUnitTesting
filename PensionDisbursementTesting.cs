using Moq;
using NUnit.Framework;
using PensionDisbursement;
using PensionDisbursement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionDisbursementTest
{
    public class Tests
    {       

        PensionDisbursementController controller = new PensionDisbursementController();

        PensionerDetail pensioner = new PensionerDetail();

        

        ProcessPensionInput pensionInput1 = new ProcessPensionInput();
        ProcessPensionInput pensionInput2 = new ProcessPensionInput();

        [SetUp]
        public void Setup()
        {
           
            pensionInput1.aadharNumber = "BCFPN1234F";
            pensionInput1.pensionAmount = 25500;
            pensionInput1.bankType = 2;

            //pensionInput2.aadharNumber = "BCDVN1234F";
            //pensionInput2.pensionAmount = 24500;
            //pensionInput2.bankType = 1;

            pensioner.allowances = 5000;
            pensioner.salaryEarned = 40000;
            pensioner.pensionType = 2;

            
        }

        [Test]
        public void ProcessDisbursement_Pension_IsNotNull()
        {
            var result = controller.GetDisbursePension(pensionInput1);
            var type1 = result;
            //var type1 = 10;
            Assert.IsNotNull(type1);
        }

        [Test]
        public void ProcessDisbursement_Pension_IsPositive()
        {
            var result = controller.GetDisbursePension(pensionInput1);
            var type1 = result;
            //var type1 = 10;

            Assert.Positive(type1);
        }

        [Test]
        public void ProcessPension_Person_Valid()
        {
            var result = controller.GetDisbursePension(pensionInput1);
            var type = result;
            var status = 10;            
            Assert.AreNotEqual(type, status);
        }

        [Test]
        public void ProcessPension_Person_Invalid()
        {
            var result = controller.GetDisbursePension(pensionInput1);
            var type = result;
            var status = 21;
            Assert.AreEqual(result, status);
        }

    }
}