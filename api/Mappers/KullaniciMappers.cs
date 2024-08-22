using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Kullanici;
using api.Models;

namespace api.Mappers
{
    public static class KullaniciMappers
    {
        public static KullaniciDto toKullaniciDto(this Kullanici kullaniciModel){
            return new KullaniciDto{
                KullaniciAdi = kullaniciModel.KullaniciAdi,
                Sifre = kullaniciModel.Sifre,
                Rol = kullaniciModel.Rol
            };
        }
    }
}