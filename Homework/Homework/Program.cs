using System;
using System.Text;

namespace Program;

class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        // Testing
        Car bmw = new Car(
            500, 250.50, 4, "BMW X5", 4, FuelType.Gas
            );
        Console.WriteLine(bmw);
        bmw.Move();
        bmw.OpenBag();

        Train train = new Train(
            10000, 50, 50, TrainType.Passenger, 10);
        Console.WriteLine(train);
        train.RotateWheels();
        train.MakeSound();

        Express express = new Express(
            50000, 250, 100, TrainType.Passenger, 3, 250, true);
        Console.WriteLine(express);
        express.SatPassengers();
    }
}

public abstract class Vehicle
{
    protected double _weight;
    protected double _speed;
    protected int _seats;

    public abstract void Move();
    public abstract void Stop();
    public abstract void MakeSound();

    protected Vehicle(double weight, double speed, int seats)
    {
        _weight = weight;
        _speed = speed;
        _seats = seats;
    }
}

public enum FuelType
{
    Diesel,
    Gas,
    Hydrogen
}

public class Car : Vehicle
{
    private string? _name;
    private int _doorQuantity;
    private FuelType _fuelType;

    public Car(double weight, double speed, int seats,
        string name, int doorQuantity, FuelType fuelType)
    : base(weight, speed, seats)
    {
        _name = name;
        _doorQuantity = doorQuantity;
        _fuelType = fuelType;
    }

    public void OpenBag()
        => Console.WriteLine("Багажник открыт!");

    public override void Move()
        => Console.WriteLine($"Машина передвигается со скоростью {this._speed}");

    public override void Stop()
        => Console.WriteLine($"Машина остановлена.");

    public override void MakeSound()
        => Console.WriteLine("Beep beep!");


    public override string ToString()
        => $"Машина {_name} на топливе {_fuelType.ToString()} с {_doorQuantity} дверьми";
}

public enum TrainType
{
    Passenger,
    ArmoredTrain,
    ElectricTrain,
    Cargo,
}

class Train : Vehicle
{
    private TrainType _trainType;
    private int _carriageQuantity;
    
    public Train(double weight, double speed, int seats,
        TrainType trainType, int carriageQuantity) : base(weight, speed, seats)
    {
        _trainType = trainType;
        _carriageQuantity = carriageQuantity;
    }

    public override void Move()
        => Console.WriteLine($"Поезд движется со скоростью {this._speed}");

    public override void Stop()
        => Console.WriteLine("Поезд остановлен.");

    public override void MakeSound()
        => Console.WriteLine("Чух - чух!");

    public void RotateWheels()
        => Console.WriteLine("Поезд поменял траекторию движения");

    public override string ToString()
        => $"Поезд типа {_trainType.ToString()} с {_carriageQuantity} вагонами";
}

class Express : Train
{
    private int _passengersQuantity;
    private bool _haveWifi;
    
    public Express(double weight, double speed, int seats, TrainType trainType, int carriageQuantity,
        int passengersQuantity, bool haveWifi) : base(weight, speed, seats, trainType, carriageQuantity)
    {
        _passengersQuantity = passengersQuantity;
        _haveWifi = haveWifi;
    }

    public void SatPassengers()
        => Console.WriteLine($"Поезд заполнен {_passengersQuantity} пассажирами");

    public override string ToString()
    {
        string wifi = _haveWifi ? "с" : "без";
        return $"Экспресс поезд с {_passengersQuantity} пассажирами и {wifi} вайфай.";
    }
}