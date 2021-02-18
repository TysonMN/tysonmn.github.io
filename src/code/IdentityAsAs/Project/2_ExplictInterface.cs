namespace ExplictInterface {
  interface IPlanet {
    bool HasLife { get; }
  }

  class Earth : IPlanet {
    bool IPlanet.HasLife => true;
  }

  class Sandbox {
    public bool EarthHasLife() => new Earth().As<IPlanet>().HasLife;
  }
}