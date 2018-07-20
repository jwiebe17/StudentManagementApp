using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMangement.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> DegreeID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public string DegreeName { get; set; }

        //Instance Variables
        public IBuyCreditsBehavior buyCreditsBehavior;
        public IRegisterClassBehavior registerClassBehavior;
        public IRetrieveTranscript retrieveTranscriptBehavior;

        //Delegate to Behavior class
        public void BuyCafeteriaCredits()
        {
            buyCreditsBehavior.buyCredits();
        }
        public void RegisterForClass()
        {
            registerClassBehavior.regClass();
        }
        public void RetrieveTranscript()
        {
            retrieveTranscriptBehavior.retTranscript();
        }
    }

    //Buy Credits interface
    public interface IBuyCreditsBehavior
    {
        void buyCredits();
    }

    //Buy Credits Implementation Classes
    public class DocBuyCredits : IBuyCreditsBehavior
    {

        public void buyCredits()
        {
            Console.WriteLine("Bought Doctorate Credits");
        }

    }
    public class UnderGradBuyCredits : IBuyCreditsBehavior
    {

        public void buyCredits()
        {
            Console.WriteLine("Bought UndegGraduate Credits");
        }
    }
    public class GradBuyCredits : IBuyCreditsBehavior
    {

        public void buyCredits()
        {
            Console.WriteLine("Bought Graduate Credits");
        }
    }

    //Register Class Interface
    public interface IRegisterClassBehavior
    {
        void regClass();
    }

    //Register Class Implementation classes
    public class DocRegisterForClass : IRegisterClassBehavior
    {
        public void regClass()
        {
            Console.WriteLine("Registered Doctorate Class");
        }
    }
    public class UnderGradRegisterForClass : IRegisterClassBehavior
    {
        public void regClass()
        {
            Console.WriteLine("Registered Undergraduate Class");
        }
    }
    public class GradRegisterForClass : IRegisterClassBehavior
    {
        public void regClass()
        {
            Console.WriteLine("Registered Graduate Class");
        }
    }

    //Retrieve Transcript Interface
    public interface IRetrieveTranscript
    {
        void retTranscript();
    }

    //Retrieve Transcript Implementation Classes
    public class DocRetrieveTranscript : IRetrieveTranscript
    {
        public void retTranscript()
        {
            Console.WriteLine("Retrieved Doctorate Transcript");
        }
    }
    public class UnderGradRetrieveTranscript : IRetrieveTranscript
    {
        public void retTranscript()
        {
            Console.WriteLine("Retrieved Undergraduate Transcript");
        }
    }
    public class GradRetrieveTranscript : IRetrieveTranscript
    {
        public void retTranscript()
        {
            Console.WriteLine("Retrieved Graduate Transcript");
        }
    }

    public class Doctorate : StudentViewModel
    {
        public void DoctorateBuyCafeteriaCredits()
        {
            buyCreditsBehavior = new DocBuyCredits();
        }
        public void DoctorateRegisterForClass()
        {
            registerClassBehavior = new DocRegisterForClass();
        }
        public void DoctorateRetrieveTranscript()
        {
            retrieveTranscriptBehavior = new DocRetrieveTranscript();
        }
    }

    public class Graduate : StudentViewModel
    {
        public void GraduateBuyCafeteriaCredits()
        {
            buyCreditsBehavior = new GradBuyCredits();
        }
        public void GraduateRegisterForClass()
        {
            registerClassBehavior = new GradRegisterForClass();
        }
        public void GraduateRetrieveTranscript()
        {
            retrieveTranscriptBehavior = new GradRetrieveTranscript();
        }
    }

    public class UnderGraduate : StudentViewModel
    {
        public void UnderGradBuyCafeteriaCredits()
        {
            buyCreditsBehavior = new UnderGradBuyCredits();
        }
        public void UnderGradRegisterForClass()
        {
            registerClassBehavior = new UnderGradRegisterForClass();
        }
        public void UnderGradRetrieveTranscript()
        {
            retrieveTranscriptBehavior = new UnderGradRetrieveTranscript();
        }
    }
}