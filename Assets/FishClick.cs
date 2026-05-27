using UnityEngine;
using TMPro; // Wajib buat TextMeshPro

public class FishClick : MonoBehaviour {
    public bool isSapuSapu; 
    public string namaIkan;
    public string deskripsi;
    public static int score = 0;
    
    private float waktuPencet;
    private HealthManager healthManager; 
    private TMP_Text teksSkor;

    void Start() {
        // Cari pengatur nyawa & teks skor di layar otomatis
        healthManager = FindFirstObjectByType<HealthManager>();
        teksSkor = FindFirstObjectByType<TMP_Text>(); 
    }

    void OnMouseDown() {
        waktuPencet = Time.time; 
    }

    void OnMouseUp() {
        float lamaDitekan = Time.time - waktuPencet;

        if (lamaDitekan > 0.5f) {
            Debug.Log("MASUK ALBUM: " + namaIkan);
        } 
        else {
            if (isSapuSapu) {
                // Kalo bener: Tambah skor & update teks
                score++;
                if (teksSkor != null) teksSkor.text = "Skor : " + score;
            } else {
                // Kalo salah: Nyawa/hati berkurang
                if (healthManager != null) healthManager.TakeDamage();
            }
            Destroy(gameObject); 
        }
    }
}