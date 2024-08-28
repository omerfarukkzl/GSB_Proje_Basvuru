import 'package:equatable/equatable.dart';

abstract class AltTipEvent extends Equatable {
  @override
  List<Object> get props => [];
}

class FetchTipler extends AltTipEvent {}

class AddAltTip extends AltTipEvent {
  final String tipId;
  final String altTipAd;

  AddAltTip(this.tipId, this.altTipAd);

  @override
  List<Object> get props => [tipId, altTipAd];
}
