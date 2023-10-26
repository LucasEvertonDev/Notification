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
    public UsuarioModel(string strings, int ints, int? intNull, short int16, int int32, long int64, short? int16Null, int? int32Null, long? int64Null, DateTime dateTime, DateTime? dateTimeNull, bool boooelan, bool? boooelanNull, decimal decimalx, decimal? decimalNull, short shortx, short? shortxNull, long longx, long? longxNull)
    {
        Set(u => u.strings, strings).ValidateWhen().IsNullOrEmpty().AddFailure(Error.String);
        Set(u => u.ints, ints).ValidateWhen().Is(ints == 0).AddFailure(Error.Ints);
        Set(u => u.intNull, intNull).ValidateWhen().IsNull().AddFailure(Error.intNull);
        Set(u => u.int16, int16).ValidateWhen().Is(int16 == 0).AddFailure(Error.int16);
        Set(u => u.int32, int32).ValidateWhen().Is(int32 == 0).AddFailure(Error.int32);
        Set(u => u.int64, int64).ValidateWhen().Is(int64 == 0).AddFailure(Error.int64);
        Set(u => u.int16Null, int16Null).ValidateWhen().IsNull().AddFailure(Error.int16Null);
        Set(u => u.int32Null, int32Null).ValidateWhen().IsNull().AddFailure(Error.int32Null);
        Set(u => u.int64Null, int64Null).ValidateWhen().IsNull().AddFailure(Error.int64Null);
        Set(u => u.DateTime, dateTime).ValidateWhen().Is(DateTime == DateTime.MinValue).AddFailure(Error.DateTime);
        Set(u => u.DateTimeNull, dateTimeNull).ValidateWhen().IsNull().AddFailure(Error.DateTimeNull);
        Set(u => u.boooelan, boooelan).ValidateWhen().Is(boooelan).AddFailure(Error.boooelan);
        Set(u => u.boooelanNull, boooelanNull).ValidateWhen().IsNull().AddFailure(Error.boooelanNull);
        Set(u => u.decimalx, decimalx).ValidateWhen().Is(decimalx == 0).AddFailure(Error.decimalx);
        Set(u => u.decimalNull, decimalNull).ValidateWhen().IsNull().AddFailure(Error.decimalNull);
        Set(u => u.shortx, shortx).ValidateWhen().Is(shortx == 0).AddFailure(Error.shortx);
        Set(u => u.shortxNull, shortxNull).ValidateWhen().IsNull().AddFailure(Error.shortxNull);
        Set(u => u.longx, longx).ValidateWhen().Is(longx == 0).AddFailure(Error.longx);
        Set(u => u.longxNull, longxNull).ValidateWhen().IsNull().AddFailure(Error.longxNull);
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