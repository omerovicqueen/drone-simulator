# Proje Geliştirme Kuralları

## Unity bileşen referansları

- `GetComponent`, `GetComponentInChildren`, `GetComponentInParent` ve benzeri çalışma zamanı bileşen aramalarını mümkün olduğunca kullanma.
- `Camera.main`, `FindObjectOfType`, `FindFirstObjectByType`, `FindAnyObjectByType` ve benzeri sahne aramalarından kaçın.
- Bileşen bağımlılıklarını tercihen `[SerializeField] private` alanlar üzerinden Inspector'dan açıkça ata.
- Zorunlu referansları `Awake` içinde doğrula. Referans eksikse açıklayıcı bir hata yaz ve bileşenin hatalı şekilde çalışmasını engelle.
- `RequireComponent`, gerekli bileşenin GameObject üzerinde bulunmasını garanti etmek için kullanılabilir; ancak referansı yine Inspector üzerinden açıkça bağla.
- Yalnızca dinamik oluşturulan nesneler veya Inspector referansının uygulanabilir olmadığı durumlarda çalışma zamanı araması kullan. Böyle bir istisnanın nedenini kod yorumunda açıkla.
