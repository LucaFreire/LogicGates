bool[] valores = new bool[]{true , true};

GateAND and = new GateAND(true, true);

GateOR or = new GateOR(and.GetValue(), false);

Console.WriteLine(or.GetValue());





