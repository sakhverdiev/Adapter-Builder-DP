using System;

namespace Builder_DP;

interface IBuilder
{
    void reset();
    void setSeats(int number);
    void setEngine(string engine);
    void setTripComputer();
    void setGPS();
}


class CarBuilder : IBuilder
{

    private Car car;

    public void reset()
    {
        this.car = new Car();
    }

    public void setEngine(string engine) { }

    public void setGPS() { }

    public void setSeats(int number) { }

    public void setTripComputer() { }

    public Car getResult() { return this.car; }
}


class CarManualBuilder : IBuilder
{

    private Manual manual;

    public void reset()
    {
        this.manual = new Manual();
    }

    public void setEngine(string engine) { }

    public void setGPS() { }

    public void setSeats(int number) { }

    public void setTripComputer() { }

    public Manual getResult()
    {
        return this.manual;
    }
}


class Director
{
    public void makeSUV(IBuilder builder) { }

    public void makeSportsCar(IBuilder builder)
    {
        builder.reset();
        builder.setSeats(2);
        builder.setEngine("Sports Car");
        builder.setTripComputer();
        builder.setGPS();
    }
}


class Car : CarBuilder
{
    // ...
}


class Manual : CarManualBuilder
{
    // ...
}


// Client
class Program
{
    public void Main()
    {
        Director director = new Director();
        CarBuilder builder = new CarBuilder();
        director.makeSportsCar(builder);
        Car car = builder.getResult();
    }
}