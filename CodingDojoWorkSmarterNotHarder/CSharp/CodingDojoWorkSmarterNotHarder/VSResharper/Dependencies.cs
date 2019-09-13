namespace CodingDojoWorkSmarterNotHarder.VSResharper
{
    public interface IDependency
    {
        void DoStuff();
    }

    public interface IAnotherDependency
    {
        void DoMoreStuff();
    }

    public abstract class SomeBase
    {
        private readonly IDependency _dependency;

        protected SomeBase(IDependency dependency) // inject IAnotherDependency here
        {
            _dependency = dependency;
        }

        public void RunTheEntireShow()
        {
            _dependency.DoStuff();
            // some instructions
            DoDerivedStuff();
            // some more instructions

            // ... and here i would need:
            //_anotherDependency.DoMoreStuff();
        }

        protected abstract void DoDerivedStuff();
    }

    public class AnImplementation : SomeBase
    {
        public AnImplementation(IDependency dependency) 
            : base(dependency) { }

        protected override void DoDerivedStuff()
        {
            // instructions
        }
    }

    public class AnotherImplementation : SomeBase
    {
        public AnotherImplementation(IDependency dependency)
            : base(dependency) { }

        protected override void DoDerivedStuff()
        {
            // other instructions
        }
    }

    // ... and another and another ... seemingly endless list of derivatives
}
