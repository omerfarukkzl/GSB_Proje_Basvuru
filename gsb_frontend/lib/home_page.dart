import 'package:flutter/material.dart';
import 'package:gsb_frontend/view/applicationPages/application_list_view.dart';
import 'package:shared_preferences/shared_preferences.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  String? username;
  String? role;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _loadUserInfo();
  }

  Future<void> _loadUserInfo() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    setState(() {
      username = prefs.getString('username');
      role = prefs.getString('role');
      isLoading = false; // Bilgiler yüklendiğinde loading biter
    });
  }

  Future<void> _logout(BuildContext context) async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    await prefs.clear(); // Tüm verileri temizler

    // Giriş sayfasına yönlendirin
    Navigator.pushReplacementNamed(context, '/');
  }

  @override
  Widget build(BuildContext context) {
    if (isLoading) {
      return Scaffold(
        appBar: AppBar(title: Text('Ana Sayfa')),
        body: Center(child: CircularProgressIndicator()),
      );
    }

    return Scaffold(
      appBar: AppBar(title: Text('Ana Sayfa')),
      drawer: Drawer(
        child: ListView(
          children: [
            Material(
              color: Colors.grey,
              child: InkWell(
                onTap: () {
                  Navigator.pop(context);
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => ApplicationListPage()),
                  );
                },
                child: Container(
                  padding: EdgeInsets.only(
                      top: MediaQuery.of(context).padding.top, bottom: 24),
                  child: const Column(
                    children: [
                      CircleAvatar(
                        radius: 52,
                        backgroundImage: AssetImage('assets/gsb_logo.png'),
                      ),
                      SizedBox(
                        height: 12,
                      ),
                      FittedBox(
                        child: Text(
                          'Gençlik ve Spor Bakanlığı \n       Başvuru Yönetimi',
                          style: TextStyle(fontSize: 28, color: Colors.white),
                        ),
                      ),
                      Text(
                        '@gsb.gov.tr',
                        style: TextStyle(fontSize: 14, color: Colors.white),
                      ),
                    ],
                  ),
                ),
              ),
            ),
            ExpansionTile(
              leading: Icon(Icons.assignment),
              title: Text('Başvuru İşlemleri'),
              children: [
                ListTile(
                  title: Text('Başvuru Yap'),
                  onTap: () {
                    Navigator.pushNamed(context, '/application');
                  },
                ),
                ListTile(
                  title: Text('Başvuru Listele'),
                  onTap: () {
                    Navigator.pushNamed(context, '/applicationList');
                  },
                ),
              ],
            ),
            ExpansionTile(
              leading: Icon(Icons.category),
              title: Text('Referans İşlemleri'),
              children: [
                ListTile(
                  title: Text('AltTip Ekle'),
                  onTap: () {
                    Navigator.pushNamed(context, '/AltTipEkle');
                  },
                ),
                ListTile(
                  title: Text('AltTip Listele'),
                  onTap: () {
                    Navigator.pushNamed(context, '/AltTipListele');
                  },
                )
              ],
            ),
            if (role == 'admin')
              ExpansionTile(
                leading: Icon(Icons.person),
                title: Text('Kullanıcı İşlemleri'),
                children: [
                  ListTile(
                    title: Text('Kullanıcı Ekle'),
                    onTap: () {
                      Navigator.pushNamed(context, '/userEkle');
                    },
                  ),
                  ListTile(
                    title: Text('Kullanıcı Listele'),
                    onTap: () {
                      Navigator.pushNamed(context, '/userListele');
                    },
                  ),
                ],
              ),
            ListTile(
              leading: Icon(Icons.logout),
              title: Text('Çıkış Yap'),
              onTap: () {
                _logout(context);
              },
            ),
          ],
        ),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text('Hoşgeldin $username!'),
            Text('$role rolü ile giriş yaptınız.'),
            SizedBox(height: 20),
            if (role == 'admin')
              ElevatedButton(
                onPressed: () {
                  Navigator.pushReplacementNamed(context, '/userEkle');
                },
                child: Text('Kullanıcı Ekle'),
              ),
          ],
        ),
      ),
    );
  }
}
