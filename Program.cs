bool[] valores = new bool[]{true , false};

GateAND and = new GateAND(valores);

Console.WriteLine(and.FindValue());

























public abstract class Components
{
    // public bool value { get; set; } = false;
    protected bool[] valores { get; set; }
    protected int index { get; set; } = 0;
    public Components(bool[] values)
    {
        for (int i = 0; i < values.Count(); i++)
        {    
            this.valores[index] =  values[index];
            this.index++;
        }
    }
    
    // public virtual void TurnON() => this.value = true;
    public virtual bool FindValue() => false;
}

public class GateAND : Components 
{
    public GateAND(bool[] values) : base(values) { }
    public override bool FindValue() =>  !valores.Take(index).Any(x => !x);

}

public class GateNOT : Components 
{
    // TODO: only accept one value to GateNOT
    public GateNOT(bool[] values) : base(values) { }
    public override bool FindValue() =>  !valores[0];

}

public class GateOR : Components 
{
    public GateOR(bool[] values) : base(values) { }
    public override bool FindValue() => !valores.Take(index).Any(x => x);

}
