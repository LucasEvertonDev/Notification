﻿using Notification.Notifications;
using Notifications.Notifiable.Notifications;

namespace Notification.Tests.Domain.Models;


public class Error
{
    public static FailureModel String = new FailureModel("String", "String é obrigatoria");

    public static FailureModel Ints = new FailureModel("Ints", "ints é obrigatoria");

    public static FailureModel intNull = new FailureModel("intNull", "intNull é obrigatoria");

    public static FailureModel int16 = new FailureModel("int16", "int16 é obrigatoria");

    public static FailureModel int32 = new FailureModel("int32", "int32 é obrigatoria");

    public static FailureModel int64 = new FailureModel("int64", "int64 é obrigatoria");

    public static FailureModel int16Null = new FailureModel("int16Null", "int16Null é obrigatoria");

    public static FailureModel int32Null = new FailureModel("int32Null", "int32Null é obrigatoria");

    public static FailureModel int64Null = new FailureModel("int64Null", "int64Null é obrigatoria");

    public static FailureModel DateTime = new FailureModel("DateTime", "DateTime é obrigatoria");

    public static FailureModel DateTimeNull = new FailureModel("DateTimeNull", "DateTimeNull é obrigatoria");

    public static FailureModel boooelan = new FailureModel("boooelan", "boooelan é obrigatoria");

    public static FailureModel boooelanNull = new FailureModel("boooelanNull", "boooelanNull é obrigatoria");

    public static FailureModel decimalx = new FailureModel("decimalx", "decimalx é obrigatoria");

    public static FailureModel decimalNull = new FailureModel("decimalNull", "decimalNull é obrigatoria");

    public static FailureModel shortx = new FailureModel("shortx", "shortx é obrigatoria");

    public static FailureModel shortxNull = new FailureModel("shortxNull", "shortxNull é obrigatoria");

    public static FailureModel longx = new FailureModel("longx", "longx é obrigatoria");

    public static FailureModel longxNull = new FailureModel("longxNull", "longxNull é obrigatoria");
}

public class UsuarioModel : Notifiable<UsuarioModel>
{
    public UsuarioModel()
    {
        
    }

    public UsuarioModel(string strings, int ints, int? intNull, short int16, int int32, long int64, short? int16Null, int? int32Null, long? int64Null, DateTime dateTime, DateTime? dateTimeNull, bool boooelan, bool? boooelanNull, decimal decimalx, decimal? decimalNull, short shortx, short? shortxNull, long longx, long? longxNull)
    {
        Set(u => u.strings, strings).AndValidate().IsNullOrEmpty().AddFailure(Error.String);
        Set(u => u.ints, ints).AndValidate().IsEquals(0).AddFailure(Error.Ints);
        Set(u => u.intNull, intNull).AndValidate().IsNull().AddFailure(Error.intNull);
        Set(u => u.int16, int16).AndValidate().IsEquals(0).AddFailure(Error.int16);
        Set(u => u.int32, int32).AndValidate().IsEquals(0).AddFailure(Error.int32);
        Set(u => u.int64, int64).AndValidate().IsEquals(0).AddFailure(Error.int64);
        Set(u => u.int16Null, int16Null).AndValidate().IsNull().AddFailure(Error.int16Null);
        Set(u => u.int32Null, int32Null).AndValidate().IsNull().AddFailure(Error.int32Null);
        Set(u => u.int64Null, int64Null).AndValidate().IsNull().AddFailure(Error.int64Null);
        Set(u => u.DateTime, dateTime).AndValidate().Is(DateTime == DateTime.MinValue).AddFailure(Error.DateTime);
        Set(u => u.DateTimeNull, dateTimeNull).AndValidate().IsNull().AddFailure(Error.DateTimeNull);
        Set(u => u.boooelan, boooelan).AndValidate().Is(boooelan).AddFailure(Error.boooelan);
        Set(u => u.boooelanNull, boooelanNull).AndValidate().IsNull().AddFailure(Error.boooelanNull);
        Set(u => u.decimalx, decimalx).AndValidate().Is(decimalx == 0).AddFailure(Error.decimalx);
        Set(u => u.decimalNull, decimalNull).AndValidate().IsNull().AddFailure(Error.decimalNull);
        Set(u => u.shortx, shortx).AndValidate().IsEquals(0).AddFailure(Error.shortx);
        Set(u => u.shortxNull, shortxNull).AndValidate().IsNull().AddFailure(Error.shortxNull);
        Set(u => u.longx, longx).AndValidate().IsEquals(0).AddFailure(Error.longx);
        Set(u => u.longxNull, longxNull).AndValidate().IsNull().AddFailure(Error.longxNull);
    }

    public UsuarioModel CriarUsuario2(string strings, int ints, int? intNull, short int16, int int32, long int64, short? int16Null, int? int32Null, long? int64Null, DateTime dateTime, DateTime? dateTimeNull, bool boooelan, bool? boooelanNull, decimal decimalx, decimal? decimalNull, short shortx, short? shortxNull, long longx, long? longxNull)
    {
        Set(u => u.strings, strings).AndValidate().IsNullOrEmpty(Error.String);
        Set(u => u.ints, ints).AndValidate().IsZero(Error.Ints);
        Set(u => u.intNull, intNull).AndValidate().IsNull(Error.intNull);
        Set(u => u.int16, int16).AndValidate().IsZero(Error.int16);
        Set(u => u.int32, int32).AndValidate().IsZero(Error.int32);
        Set(u => u.int64, int64).AndValidate().IsZero(Error.int64);
        Set(u => u.int16Null, int16Null).AndValidate().IsNull(Error.int16Null);
        Set(u => u.int32Null, int32Null).AndValidate().IsNull(Error.int32Null);
        Set(u => u.int64Null, int64Null).AndValidate().IsNull(Error.int64Null);
        Set(u => u.DateTime, dateTime).AndValidate().IsMinValue(Error.DateTime);
        Set(u => u.DateTimeNull, dateTimeNull).AndValidate().IsNull(Error.DateTimeNull);
        Set(u => u.boooelan, boooelan).AndValidate().IsTrue(Error.boooelan);
        Set(u => u.boooelanNull, boooelanNull).AndValidate().IsNull(Error.boooelanNull);
        Set(u => u.decimalx, decimalx).AndValidate().IsZero(Error.decimalx);
        Set(u => u.decimalNull, decimalNull).AndValidate().IsNull(Error.decimalNull);
        Set(u => u.shortx, shortx).AndValidate().IsZero(Error.shortx);
        Set(u => u.shortxNull, shortxNull).AndValidate().IsNull(Error.shortxNull);
        Set(u => u.longx, longx).AndValidate().IsZero(Error.longx);
        Set(u => u.longxNull, longxNull).AndValidate().IsNull(Error.longxNull);

        return this;
    }

    public UsuarioModel CriarUsuario(string strings, int ints, int? intNull, short int16, int int32, long int64, short? int16Null, int? int32Null, long? int64Null, DateTime dateTime, DateTime? dateTimeNull, bool boooelan, bool? boooelanNull, decimal decimalx, decimal? decimalNull, short shortx, short? shortxNull, long longx, long? longxNull)
    {
        if (string.IsNullOrEmpty(strings))
        {
            Result.Failure<UsuarioModel>(u => u.strings, Error.String);
        }

        if (ints == 0)
        {
            Result.Failure<UsuarioModel>(u => u.ints, Error.Ints);
        }

        if (intNull == null)
        {
            Result.Failure<UsuarioModel>(u => u.intNull, Error.intNull);
        }

        if (int16 == 0)
        {
            Result.Failure<UsuarioModel>(u => u.int16, Error.int16);
        }

        if (int32 == 0)
        {
            Result.Failure<UsuarioModel>(u => u.int32, Error.int32);
        }

        if (int64 == 0)
        {
            Result.Failure<UsuarioModel>(u => u.int64, Error.int64);
        }

        if (int16Null == null)
        {
            Result.Failure<UsuarioModel>(u => u.int16Null, Error.int16Null);
        }

        if (int32Null == null)
        {
            Result.Failure<UsuarioModel>(u => u.int32Null, Error.int32Null);
        }

        if (int64Null == null)
        {
            Result.Failure<UsuarioModel>(u => u.int64Null, Error.int64Null);
        }

        if (dateTime == DateTime.MinValue)
        {
            Result.Failure<UsuarioModel>(u => u.DateTime, Error.DateTime);
        }

        if (dateTimeNull == null)
        {
            Result.Failure<UsuarioModel>(u => u.DateTimeNull, Error.DateTimeNull);
        }

        if (boooelan)
        {
            Result.Failure<UsuarioModel>(u => u.boooelan, Error.boooelan);
        }

        if (boooelanNull == null)
        {
            Result.Failure<UsuarioModel>(u => u.boooelanNull, Error.boooelanNull);
        }

        if (decimalx == 0)
        {
            Result.Failure<UsuarioModel>(u => u.decimalx, Error.decimalx);
        }

        if (decimalNull == null)
        {
            Result.Failure<UsuarioModel>(u => u.decimalNull, Error.decimalNull);
        }

        if (shortx == 0)
        {
            Result.Failure<UsuarioModel>(u => u.shortx, Error.shortx);
        }

        if (shortxNull == null)
        {
            Result.Failure<UsuarioModel>(u => u.shortxNull, Error.shortxNull);
        }

        if (longx == 0)
        {
            Result.Failure<UsuarioModel>(u => u.longx, Error.longx);
        }

        if (longxNull == null)
        {
            Result.Failure<UsuarioModel>(u => u.longxNull, Error.longxNull);
        }

        this.strings = strings;
        this.ints = ints;
        this.intNull = intNull;
        this.int16 = int16;
        this.int32 = int32;
        this.int64 = int64;
        this.int16Null = int16Null;
        this.int32Null = int32Null;
        this.int64Null = int64Null;
        this.DateTime = dateTime;
        this.DateTimeNull = dateTimeNull;
        this.boooelan = boooelan;
        this.boooelanNull = boooelanNull;
        this.decimalx = decimalx;
        this.decimalNull = decimalNull;
        this.shortx = shortx;
        this.shortxNull = shortxNull;
        this.longx = longx;
        this.longxNull = longxNull;

        return this;
    }

    public string strings { get; private set; }

    public int ints { get; private set; }

    public int? intNull { get; private set; }    

    public Int16 int16 { get; private set; }

    public Int32 int32 { get; private set;}

    public Int64 int64 { get; private set;}

    public Int16? int16Null { get; private set; }

    public Int32? int32Null { get; private set; }

    public Int64? int64Null { get; private set; }

    public DateTime DateTime { get; private set; }

    public DateTime? DateTimeNull { get; private set; }

    public bool boooelan { get; private set; }

    public bool? boooelanNull { get; private set; }

    public decimal decimalx { get; private set; }

    public decimal? decimalNull { get; private set; }

    public short shortx { get; private set; }

    public short? shortxNull { get;private set; }

    public long longx { get; private set; }

    public long? longxNull { get; private set; }
}
