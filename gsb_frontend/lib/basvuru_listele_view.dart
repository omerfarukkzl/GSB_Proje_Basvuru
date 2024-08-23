import 'package:flutter/material.dart';

class BasvuruListelePage extends StatelessWidget {
  // Örnek veriler (Gerçek veriler API veya veritabanından alınabilir)
  final List<Map<String, String>> basvuruListesi = [
    {
      "projeAdi": "Proje 1",
      "basvuranBirim": "Birim A",
      "basvuruYapilanProje": "Proje A",
      "basvuruYapilanTur": "Tür 1",
      "katilimciTuru": "Katılımcı 1",
      "basvuruDonemi": "R1",
      "basvuruTarihi": "2024-01-01",
      "basvuruDurumu": "Kabul"
    },
    {
      "projeAdi": "Proje 2",
      "basvuranBirim": "Birim B",
      "basvuruYapilanProje": "Proje B",
      "basvuruYapilanTur": "Tür 2",
      "katilimciTuru": "Katılımcı 2",
      "basvuruDonemi": "R2",
      "basvuruTarihi": "2024-02-01",
      "basvuruDurumu": "Red"
    },
    // Diğer başvurular
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Başvuru Listeleme'),
      ),
      drawer: _buildDrawer(context), // Drawer'ı burada da ekleyelim
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: ListView.builder(
          itemCount: basvuruListesi.length,
          itemBuilder: (context, index) {
            final basvuru = basvuruListesi[index];
            return Card(
              child: ListTile(
                title: Text(basvuru['projeAdi'] ?? ''),
                subtitle: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text("Başvuran Birim: ${basvuru['basvuranBirim']}"),
                    Text(
                        "Başvuru Yapılan Proje: ${basvuru['basvuruYapilanProje']}"),
                    Text(
                        "Başvuru Yapılan Tür: ${basvuru['basvuruYapilanTur']}"),
                    Text("Katılımcı Türü: ${basvuru['katilimciTuru']}"),
                    Text("Başvuru Dönemi: ${basvuru['basvuruDonemi']}"),
                    Text("Başvuru Tarihi: ${basvuru['basvuruTarihi']}"),
                    Text("Başvuru Durumu: ${basvuru['basvuruDurumu']}"),
                  ],
                ),
              ),
            );
          },
        ),
      ),
    );
  }

  // Drawer (Sol Menü) Yapısı
  Widget _buildDrawer(BuildContext context) {
    return Drawer(
      child: ListView(
        padding: EdgeInsets.zero,
        children: <Widget>[
          DrawerHeader(
            decoration: BoxDecoration(
              color: Colors.blue,
            ),
            child: Text(
              'GSB Menü',
              style: TextStyle(
                color: Colors.white,
                fontSize: 24,
              ),
            ),
          ),
          ListTile(
            leading: Icon(Icons.home),
            title: Text('Başvuru İşlemleri'),
            onTap: () {
              Navigator.pushReplacementNamed(context, '/basvuru-form');
            },
          ),
          ListTile(
            leading: Icon(Icons.list),
            title: Text('Başvuru Listele'),
            onTap: () {
              Navigator.pop(context); // Drawer'ı kapatmak için
            },
          ),
        ],
      ),
    );
  }
}
