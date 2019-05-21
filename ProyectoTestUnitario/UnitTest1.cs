using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.Estacionamientos.starter;

namespace ProyectoTestUnitario
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void ListaDeAutosNull()
    {
      Estacionamiento est = new Estacionamiento(10);
      Assert.IsNotNull(est.Autos);
    }

    [TestMethod]
    public void EspacioEstacionamientoIncorrecto()
    {
      Estacionamiento est = new Estacionamiento(101);
      if (est.EspacioDisponible != 101)
      {
        Assert.Fail("Espacio incorrecto {0}", est.EspacioDisponible);
      }

      Estacionamiento est2 = new Estacionamiento(0);
      if (est2.EspacioDisponible != 0)
      {
        Assert.Fail("Mal validado límite inferior {0}", est2.EspacioDisponible);
      }
    }

    [TestMethod]
    public void AgregarAutosEstacionamiento()
    {
      Estacionamiento est = new Estacionamiento(2);
      Auto a1 = new Auto("111", ConsoleColor.Black);
      Auto a2 = new Auto("222", ConsoleColor.Blue);
      Auto a3 = new Auto("333", ConsoleColor.Cyan);

      try
      {
        est += a1;
        est += a2;
        est += a3;
        Assert.Fail("Agrega autos más allá del límite");
      }
      catch (Exception e)
      {
        Assert.IsInstanceOfType(e, typeof(EstacionamientoLlenoException));
      }
    }


    [TestMethod]
    public void AgregarAutoEspacioDisponible()
    {
      Estacionamiento est = new Estacionamiento(2);
      Auto a1 = new Auto("111", ConsoleColor.Black);
      Auto a2 = new Auto("222", ConsoleColor.Blue);

      est += a1;
      Assert.AreEqual(est.EspacioDisponible, 1);

      est += a2;
      Assert.AreEqual(est.EspacioDisponible, 0);
    }

  }
}
