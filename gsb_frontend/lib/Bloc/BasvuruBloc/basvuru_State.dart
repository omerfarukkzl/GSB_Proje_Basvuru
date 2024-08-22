import 'package:equatable/equatable.dart';

abstract class BasvuruState extends Equatable {
  const BasvuruState();

  @override
  List<Object> get props => [];
}

class BasvuruInitial extends BasvuruState {}

class BasvuruLoading extends BasvuruState {}

class ComboBoxDataLoaded extends BasvuruState {
  final List<String> basvuruProjeList;
  final List<String> basvuruTurList;
  final List<String> basvuranBirimList;
  final List<String> katilimciTuruList;
  final List<String> basvuruDonemiList;

  ComboBoxDataLoaded({
    required this.basvuruProjeList,
    required this.basvuruTurList,
    required this.basvuranBirimList,
    required this.katilimciTuruList,
    required this.basvuruDonemiList,
  });

  @override
  List<Object> get props => [
        basvuruProjeList,
        basvuruTurList,
        basvuranBirimList,
        katilimciTuruList,
        basvuruDonemiList
      ];
}

class BasvuruSuccess extends BasvuruState {}

class BasvuruFailure extends BasvuruState {}
