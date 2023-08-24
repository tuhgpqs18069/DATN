using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    public float magnetRadius = 5f; // Bán kính vùng tác động của nam châm
    public float magnetDuration = 10f; // Thời gian nam châm hoạt động

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Kiểm tra nếu nhân vật nhặt vật phẩm nam châm
        {
            StartCoroutine(ActivateMagnet(collision.gameObject));
        }
    }

    private System.Collections.IEnumerator ActivateMagnet(GameObject player)
    {
        GetComponent<SpriteRenderer>().enabled = false; // Ẩn vật phẩm nam châm
        GetComponent<Collider2D>().enabled = false; // Vô hiệu hóa collider

        // Lấy danh sách các xu trong vùng tác động
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, magnetRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Coin")) // Kiểm tra nếu đối tượng là xu
            {
                Vector2 direction = transform.position - collider.transform.position;
                float startTime = Time.time;

                // Hút xu trong thời gian nhất định
                while (Time.time - startTime < magnetDuration)
                {
                    collider.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 10f * Time.deltaTime);
                    yield return null;
                }

                Destroy(collider.gameObject); // Xoá xu khi hoàn thành
            }
        }

        Destroy(gameObject); // Xoá vật phẩm nam châm khi hoàn thành
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
