public abstract class Components
{
    protected bool[] valores { get; set; }
    protected bool ValorExtern { get; set; }
    protected int index { get; set; } = 0;
    public virtual bool GetValue() => false;

    // Sobrecarga de Construtores
    public Components(bool[] values)
    {
        this.valores = new bool[values.Count()];

        for (int i = 0; i < values.Count(); i++)
        {    
            this.valores[i] =  values[i];
            index++;
        }
    }
    public Components(bool[] values, bool valor)
    {
        this.valores = new bool[values.Count() + 1];

        for (int i = 0; i < values.Count(); i++)
        {    
            this.valores[i] =  values[i];
            index++;
        }
        this.valores[index + 1] = valor;
    }   
    public Components(bool v1, bool v2)
    {
        this.valores = new bool[]{v1, v2};
    }
    
}

public class GateAND : Components 
{
    // Sobrecarga de Construtores
    public GateAND(bool[] values) : base(values) { }
    public GateAND(bool[] values, bool valor) : base(values, valor) { }
    public GateAND(bool values, bool valor) : base(values, valor) { }

    public override bool GetValue() => !valores.Take(index).Any(x => !x);
}

public class GateOR : Components 
{
    // Sobrecarga de Construtores
    public GateOR(bool[] values) : base(values) { }
    public GateOR(bool[] values, bool valor) : base(values, valor) { }
    public GateOR(bool values, bool valor) : base(values, valor) { }

    public override bool GetValue() => !valores.Take(index).Any(x => x);
}

public class GateNOT : Components 
{
    // TODO: only accept one value to GateNOT

    // Sobrecarga de Construtores
    public GateNOT(bool[] values) : base(values) { }
    public GateNOT(bool[] values, bool valor) : base(values, valor) { }
    public GateNOT(bool values, bool valor) : base(values, valor) { }

    public override bool GetValue() => !valores[0];
}

