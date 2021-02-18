namespace TernaryOperator {
  interface IPlanet { }
  class Earth : IPlanet { }
  class Mars : IPlanet { }
  class Sandbox {
    public IPlanet GetPlanet(bool b) =>
      b ? new Earth() : new Mars().As<IPlanet>();

    public IPlanet GetPlanet2(bool b) {
      if (b) {
        return new Earth();
      } else {
        return new Mars();
      }
    }
  }
}