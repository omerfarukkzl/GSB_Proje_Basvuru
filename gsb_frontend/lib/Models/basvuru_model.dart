import 'package:json_annotation/json_annotation.dart';

part 'basvuru_model.g.dart';

@JsonSerializable()
class Basvuru {
  final String projeAdi;
  final String basvuruYapilanProje;
  final String basvuruYapilanTur;
  final String basvuranBirim;
  final String katilimciTuru;
  final String basvuruDonemi;
  final DateTime aciklamaTarihi;
  final double hibeTutari;

  Basvuru({
    required this.projeAdi,
    required this.basvuruYapilanProje,
    required this.basvuruYapilanTur,
    required this.basvuranBirim,
    required this.katilimciTuru,
    required this.basvuruDonemi,
    required this.aciklamaTarihi,
    required this.hibeTutari,
  });

  factory Basvuru.fromJson(Map<String, dynamic> json) =>
      _$BasvuruFromJson(json);
  Map<String, dynamic> toJson() => _$BasvuruToJson(this);
}
