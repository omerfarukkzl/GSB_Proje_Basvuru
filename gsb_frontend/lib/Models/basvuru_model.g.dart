// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'basvuru_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Basvuru _$BasvuruFromJson(Map<String, dynamic> json) => Basvuru(
      projeAdi: json['projeAdi'] as String,
      basvuruYapilanProje: json['basvuruYapilanProje'] as String,
      basvuruYapilanTur: json['basvuruYapilanTur'] as String,
      basvuranBirim: json['basvuranBirim'] as String,
      katilimciTuru: json['katilimciTuru'] as String,
      basvuruDonemi: json['basvuruDonemi'] as String,
      aciklamaTarihi: DateTime.parse(json['aciklamaTarihi'] as String),
      hibeTutari: (json['hibeTutari'] as num).toDouble(),
    );

Map<String, dynamic> _$BasvuruToJson(Basvuru instance) => <String, dynamic>{
      'projeAdi': instance.projeAdi,
      'basvuruYapilanProje': instance.basvuruYapilanProje,
      'basvuruYapilanTur': instance.basvuruYapilanTur,
      'basvuranBirim': instance.basvuranBirim,
      'katilimciTuru': instance.katilimciTuru,
      'basvuruDonemi': instance.basvuruDonemi,
      'aciklamaTarihi': instance.aciklamaTarihi.toIso8601String(),
      'hibeTutari': instance.hibeTutari,
    };
