namespace HiddenMembers {
  class Planet {
    public bool? HasLife => null;
  }

  class Earth : Planet {
    public new bool? HasLife => true;
  }

  class Sandbox {
    public bool? EarthAsPlanetHasLife =>
      new Earth().As<Planet>().HasLife;
  }
}