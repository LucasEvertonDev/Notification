using FluentAssertions;
using Notification.Notifications.Notifiable.Notifications;
using Notification.Tests.Domain.Models;

namespace Notification.Tests.NotificationTests;

public class UsuarioTest : Notifiable
{
    [Fact]
    public void ValidateError()
    {
        var usuario = new UsuarioModel(
            strings: null,
            ints: 0,
            intNull: null,
            int16: 0,
            int32: 0,
            int64: 0,
            int16Null: null,
            int32Null: null,
            int64Null: null,
            dateTime: DateTime.MinValue,
            dateTimeNull: null,
            boooelan: true,
            boooelanNull: null,
            decimalx: 0,
            decimalNull: null,
            shortx: 0,
            shortxNull: null,
            longx: 0,
            longxNull: null
         );

        var failures = usuario.GetFailures();

        failures.Should().Contain(Error.String);
        failures.Should().Contain(Error.Ints);
        failures.Should().Contain(Error.intNull);
        failures.Should().Contain(Error.int16);
        failures.Should().Contain(Error.int32);
        failures.Should().Contain(Error.int64);
        failures.Should().Contain(Error.int16Null);
        failures.Should().Contain(Error.int32Null);
        failures.Should().Contain(Error.int64Null);
        failures.Should().Contain(Error.DateTime);
        failures.Should().Contain(Error.DateTimeNull);
        failures.Should().Contain(Error.boooelan);
        failures.Should().Contain(Error.boooelanNull);
        failures.Should().Contain(Error.decimalx);
        failures.Should().Contain(Error.decimalNull);
        failures.Should().Contain(Error.shortx);
        failures.Should().Contain(Error.shortxNull);
        failures.Should().Contain(Error.longx);
        failures.Should().Contain(Error.longxNull);
    }

    [Fact]
    public void ValidateSucces()
    {
        var usuario = new UsuarioModel(
            strings: "strings",
            ints: 1,
            intNull: 2,
            int16: 3,
            int32: 4,
            int64: 5,
            int16Null: 6,
            int32Null: 7,
            int64Null: 8,
            dateTime: DateTime.Now.Date,
            dateTimeNull: DateTime.Now.Date.AddMonths(1),
            boooelan: false,
            boooelanNull: true,
            decimalx: 9,
            decimalNull: 10,
            shortx: 11,
            shortxNull: 12,
            longx: 13,
            longxNull: 14
         );

        var failures = usuario.GetFailures();

        failures.Should().BeNullOrEmpty();

        usuario.strings.Should().Be("strings");
        usuario.ints.Should().Be(1);
        usuario.intNull.Should().Be(2);
        usuario.int16.Should().Be(3);
        usuario.int32.Should().Be(4);
        usuario.int64.Should().Be(5);
        usuario.int16Null.Should().Be(6);
        usuario.int32Null.Should().Be(7);
        usuario.int64Null.Should().Be(8);
        usuario.DateTime.Should().Be(DateTime.Now.Date);
        usuario.DateTimeNull.Should().Be(DateTime.Now.Date.AddMonths(1));
        usuario.boooelan.Should().Be(false);
        usuario.boooelanNull.Should().Be(true);
        usuario.decimalx.Should().Be(9);
        usuario.decimalNull.Should().Be(10);
        usuario.shortx.Should().Be(11);
        usuario.shortxNull.Should().Be(12);
        usuario.longx.Should().Be(13);
        usuario.longxNull.Should().Be(14);
    }

    [Fact]
    public void ValidateErrorPadrao()
    {
        var usuario = new UsuarioModel().CriarUsuario(
            strings: null,
            ints: 0,
            intNull: null,
            int16: 0,
            int32: 0,
            int64: 0,
            int16Null: null,
            int32Null: null,
            int64Null: null,
            dateTime: DateTime.MinValue,
            dateTimeNull: null,
            boooelan: true,
            boooelanNull: null,
            decimalx: 0,
            decimalNull: null,
            shortx: 0,
            shortxNull: null,
            longx: 0,
            longxNull: null
         );

        var failures = usuario.GetFailures();

        failures.Should().Contain(Error.String);
        failures.Should().Contain(Error.Ints);
        failures.Should().Contain(Error.intNull);
        failures.Should().Contain(Error.int16);
        failures.Should().Contain(Error.int32);
        failures.Should().Contain(Error.int64);
        failures.Should().Contain(Error.int16Null);
        failures.Should().Contain(Error.int32Null);
        failures.Should().Contain(Error.int64Null);
        failures.Should().Contain(Error.DateTime);
        failures.Should().Contain(Error.DateTimeNull);
        failures.Should().Contain(Error.boooelan);
        failures.Should().Contain(Error.boooelanNull);
        failures.Should().Contain(Error.decimalx);
        failures.Should().Contain(Error.decimalNull);
        failures.Should().Contain(Error.shortx);
        failures.Should().Contain(Error.shortxNull);
        failures.Should().Contain(Error.longx);
        failures.Should().Contain(Error.longxNull);
    }

    [Fact]
    public void ValidateSuccespadrao()
    {
        var usuario = new UsuarioModel().CriarUsuario(
            strings: "strings",
            ints: 1,
            intNull: 2,
            int16: 3,
            int32: 4,
            int64: 5,
            int16Null: 6,
            int32Null: 7,
            int64Null: 8,
            dateTime: DateTime.Now.Date,
            dateTimeNull: DateTime.Now.Date.AddMonths(1),
            boooelan: false,
            boooelanNull: true,
            decimalx: 9,
            decimalNull: 10,
            shortx: 11,
            shortxNull: 12,
            longx: 13,
            longxNull: 14
         );

        var failures = usuario.GetFailures();

        failures.Should().BeNullOrEmpty();

        usuario.strings.Should().Be("strings");
        usuario.ints.Should().Be(1);
        usuario.intNull.Should().Be(2);
        usuario.int16.Should().Be(3);
        usuario.int32.Should().Be(4);
        usuario.int64.Should().Be(5);
        usuario.int16Null.Should().Be(6);
        usuario.int32Null.Should().Be(7);
        usuario.int64Null.Should().Be(8);
        usuario.DateTime.Should().Be(DateTime.Now.Date);
        usuario.DateTimeNull.Should().Be(DateTime.Now.Date.AddMonths(1));
        usuario.boooelan.Should().Be(false);
        usuario.boooelanNull.Should().Be(true);
        usuario.decimalx.Should().Be(9);
        usuario.decimalNull.Should().Be(10);
        usuario.shortx.Should().Be(11);
        usuario.shortxNull.Should().Be(12);
        usuario.longx.Should().Be(13);
        usuario.longxNull.Should().Be(14);
    }
}
