# Drone Simulator

**Unity ve C# ile geliştirdiğim, fizik tabanlı bir drone zaman yarışı.** Arazi parkurunda uç, 12 kontrol noktasını 45 saniye içinde topla ve kendi en iyi süreni geliştir.

[![Unity](https://img.shields.io/badge/Unity-6000.3.8f1-222222?logo=unity&logoColor=white)](ProjectSettings/ProjectVersion.txt)
[![C#](https://img.shields.io/badge/C%23-Gameplay-512BD4)](Assets/Scripts/Drone.cs)
[![URP](https://img.shields.io/badge/Rendering-URP-3B82F6)](Packages/manifest.json)
[![Durum](https://img.shields.io/badge/Durum-Oynanabilir%20prototip-F59E0B)](#proje-durumu)
[![Lisans](https://img.shields.io/badge/Özgün%20kod-MIT-22C55E)](LICENSE)

[English README](README.md) · [Mimari](docs/ARCHITECTURE.md) · [Varlık kaynakları](THIRD_PARTY_NOTICES.md)

![Drone Simulator — projenin Unity oyun sahnesi](docs/media/drone-simulator.png)

## Oyun deneyimi

Amaç, süre dolmadan bütün kontrol noktalarından geçmek. İrtifayı yönet, parkurda dönüş yap, hızlanma desteğini kullan ve uçuş sırasında kamera açısını değiştir. Başarılı bir turun süresini oyuncu adıyla yerel liderlik tablosuna kaydedebilirsin.

- **Fizik tabanlı uçuş:** Rigidbody kuvvetleri, yatay ve dikey sönümleme, dönüş kontrolü ve ayarlanabilir hızlanma desteği.
- **Görsel ve işitsel geri bildirim:** yumuşak gövde eğimi, dönen pervaneler, kontrol noktası sesi ve parçacık efektleri.
- **Tam tur akışı:** başlangıç menüsü, süre ve kontrol noktası göstergesi, duraklatma/devam, kazanma/kaybetme ekranı ve yeniden başlatma.
- **Üç kamera modu:** drone üzerindeki kamera, fareyle kontrol edilen yörünge kamerası ve takip kamerası.
- **Kalıcı yerel kayıtlar:** isim ve bitirme süresinin JSON ile `PlayerPrefs` içinde saklanması, en hızlı süreye göre sıralama.

## Projedeki katkım

**Azra Ömeroğlu** — oynanış programlama ve Unity sahne entegrasyonu. Bu projede girdi yönetimi, fizik, kamera davranışı, oyun durumları, arayüz ve kayıt sistemini oynanabilir bir C# prototipinde birleştirdim. Kullanılan üçüncü taraf görsel ve ses kaynakları [varlık bildirimlerinde](THIRD_PARTY_NOTICES.md) ayrı olarak belirtilmiştir.

> **CV özeti:** Fizik tabanlı hareket, olay tabanlı girdi yönetimi, farklı kamera modları, oyun durumlarına bağlı arayüz ve kalıcı yerel skor kaydı içeren bir Unity/C# drone zaman yarışı prototipi geliştirdim.

## Unity Editor'de çalıştırma

1. [Git LFS](https://git-lfs.com/) kur ve depoyu klonla:

   ```sh
   git lfs install
   git clone https://github.com/omerovicqueen/drone-simulator.git
   cd drone-simulator
   git lfs pull
   ```

2. Unity Hub üzerinden **Unity Editor 6000.3.8f1** sürümünü kur.
3. Unity Hub'da klonlanan `drone-simulator` klasörünü mevcut proje olarak ekle ve bu sürümle aç.
4. Paketlerin yüklenmesini ve varlıkların içe aktarılmasını bekle.
5. **`Assets/Scenes/Main.unity`** sahnesini aç, Play moduna gir ve **START** düğmesine bas.

Ana sahnede **12 kontrol noktası**, **45 saniyelik süre** ve **3 kat ivme sağlayan hızlanma desteği** ayarlanmıştır. Kontrol noktaları herhangi bir sırayla toplanabilir. Kazandığında adını girip **SAVE** düğmesiyle süreni kaydet.

`Edit → Project Settings → Player → Other Settings` içindeki **Active Input Handling** ayarını **Both** olarak koru. Uçuş kontrolleri Input System kullanır; yörünge kamerası eski fare eksenlerini okur. Depodaki proje bu ayarı zaten kullanır.

## Kontroller

| Girdi | İşlev |
| --- | --- |
| W / A / S / D | İleri / sola / geri / sağa hareket |
| Space | Yükselme |
| Ctrl | Alçalma |
| Q / E | Sola / sağa dönme |
| Shift basılı tutma | Hızlanma desteği |
| Esc | Duraklatma / devam |
| 1 | Drone üzerindeki kamera |
| 2 + fare hareketi | Yörünge kamerası |
| 3 | Takip kamerası |

Tuş atamaları [DroneActions.inputactions](Assets/Inputs/DroneActions.inputactions) dosyasında tanımlıdır.

## Kodu incele

| Sistem | Kaynak | İnceleme noktası |
| --- | --- | --- |
| Uçuş | [Drone.cs](Assets/Scripts/Drone.cs) | Sabit fizik adımı, kuvvetler, sönümleme, dönüş, hızlanma ve gövde eğimi |
| Girdi | [InputManager.cs](Assets/Scripts/InputManager.cs) | Input Action geri çağrılarının C# olaylarına aktarılması |
| Oyun akışı | [GameManager.cs](Assets/Scripts/GameManager.cs) | Başlangıç, oynanış, duraklatma, bitiş ve sıfırlama |
| Kontrol noktaları | [Checkpoint.cs](Assets/Scripts/Checkpoint.cs) | Tetikleme, geri bildirim ve tamamlanma kontrolü |
| Kamera | [CameraControl](Assets/Scripts/CameraControl) | Mod seçimi, hedefe bağlanma ve yörünge davranışı |
| Arayüz | [UIManager.cs](Assets/Scripts/UIManager.cs) · [UI panelleri](Assets/Scripts/UI) | Duruma bağlı ekranlar, geri sayım ve skor girişi |
| Kayıt | [PlayerScoreBoardManager.cs](Assets/Scripts/PlayerScoreBoardManager.cs) | JSON serileştirme ve yerel sıralama |

Temel teknolojiler: **Unity 6**, **C#**, **URP**, **Unity Input System**, **uGUI/TextMeshPro** ve **ProBuilder**. Paket sürümleri [manifest.json](Packages/manifest.json) ve [packages-lock.json](Packages/packages-lock.json) içinde bulunur. Kamera davranışı projeye ait scriptlerle uygulanır.

Çalışma akışı ve kaynak yapısı için [ARCHITECTURE.md](docs/ARCHITECTURE.md) belgesine bakabilirsin.

## Proje durumu

Bu proje, arcade uçuş davranışı kullanan, tek oyunculu, klavye ve fareyle oynanan bir **portföy prototipidir**. Skorlar oyuncunun bilgisayarında tutulur. Kamera ve uçuş ayarları geliştirilmeye açıktır; gerçek dünya drone aerodinamiği modellenmez. Hazır çalıştırılabilir bir oyun sürümü eklenmemiştir.

Depo, Unity proje kaynaklarını ve sahne için gerekli varlıkları içerir. Unity önbellekleri ilk açılışta yeniden oluşturduğu için ilk içe aktarma zaman alabilir.

## Lisans ve kaynaklar

Özgün oynanış kodu [MIT Lisansı](LICENSE) ile sunulur. Üçüncü taraf varlıklar ve paket içerikleri kendi lisanslarına tabidir; MIT lisansı bu içeriklerin lisansını değiştirmez. Yeniden kullanım ve dağıtım öncesinde [THIRD_PARTY_NOTICES.md](THIRD_PARTY_NOTICES.md) dosyasını incele.

Geliştiren: [Azra Ömeroğlu](https://github.com/omerovicqueen).

Büyük arazi dokuları ve arazi verileri Git LFS ile saklanır. Gerekli kaynak varlıklar yaklaşık 2,2 GB yer kaplar. Varlıkları eksiksiz indirmek için Git LFS ile klonla.
