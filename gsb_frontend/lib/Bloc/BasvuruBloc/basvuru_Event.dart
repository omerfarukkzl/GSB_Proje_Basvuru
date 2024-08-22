import 'package:equatable/equatable.dart';
import 'package:gsb_frontend/Models/basvuru_model.dart';

abstract class BasvuruEvent extends Equatable {
  const BasvuruEvent();

  @override
  List<Object> get props => [];
}

class LoadComboBoxData extends BasvuruEvent {}

class SubmitBasvuru extends BasvuruEvent {
  final Basvuru basvuru;

  const SubmitBasvuru(this.basvuru);

  @override
  List<Object> get props => [basvuru];
}
