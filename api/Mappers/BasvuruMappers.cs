using api.Dtos.Kullanici;
using api.Models;

namespace api.Mappers
{
    public static class BasvuruMappers
    {
        public static BasvuruDto toBasvuruDto(this Basvuru basvuruModel)
        {
            return new BasvuruDto
            {
                BasvuruId = basvuruModel.BasvuruId,
                ProjeAdi = basvuruModel.ProjeAdi,
                BasvuranBirim = basvuruModel.BasvuranBirim, 
                /*
                BasvuruYapilanProje = basvuruModel.BasvuruYapilanProje,
                BasvuruYapilanTur = basvuruModel.BasvuruYapilanTur,
                KatilimciTuru = basvuruModel.KatilimciTuru,
                BasvuruDonemi = basvuruModel.BasvuruDonemi,
                BasvuruDurumu = basvuruModel.BasvuruDurumu,
                BasvuruTarihi = basvuruModel.BasvuruTarihi,
                AciklamaTarihi = basvuruModel.AciklamaTarihi,
                HibeTutari = basvuruModel.HibeTutari
                */
            };
        }

        // Yeni metod: BasvuruDto'yu Basvuru modeline dönüştürme
        public static Basvuru toBasvuruModel(this BasvuruDto basvuruDto)
        {
            return new Basvuru
            {
                ProjeAdi = basvuruDto.ProjeAdi,
                BasvuranBirim = basvuruDto.BasvuranBirim,
                /*
                BasvuruYapilanProje = basvuruDto.BasvuruYapilanProje,
                BasvuruYapilanTur = basvuruDto.BasvuruYapilanTur,
                KatilimciTuru = basvuruDto.KatilimciTuru,
                BasvuruDonemi = basvuruDto.BasvuruDonemi,
                BasvuruDurumu = basvuruDto.BasvuruDurumu,
                BasvuruTarihi = basvuruDto.BasvuruTarihi,
                AciklamaTarihi = basvuruDto.AciklamaTarihi,
                HibeTutari = basvuruDto.HibeTutari
                */
            };
        }
    }
}