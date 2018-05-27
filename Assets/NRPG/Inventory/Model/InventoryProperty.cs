using System;
using System.Collections;
using System.Collections.Generic;
using Expressive;

namespace NRPG {

  public class InventoryPropertyDefinition {

    public string Id;
    public string Name;
    public string Tags;
    public float Value;

  }

  public class InventoryPropertyFomula {
    public string Id;
    public string Name;
    public string Fomula;
    public Dictionary<string, object> Args;
    
    private Expression mExpression;

    public float Compute(float value) {
      if (mExpression == null) {
        mExpression = new Expression(Fomula);
      }
      Args["v"] = value;
      return float.Parse(mExpression.Evaluate(Args).ToString());
    }
  }

  public class InventoryProperty {

    public InventoryPropertyDefinition Definition;
    public InventoryPropertyFomula Fomula;

    public string Name {
      get { return Definition.Name; }
    }

    public float Value {
      get { 
        float value = this.Definition.Value;
        if (Fomula != null) {
          value = Fomula.Compute(value);
        }
        return value;
      }
    }

  }

}