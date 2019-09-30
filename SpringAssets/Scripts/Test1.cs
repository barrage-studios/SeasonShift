Using UnityEngine;

public Player : public Class
{
  public float ft;
  private Rigidbody rb;
  
  void Start() {
    rb = GetComponent<Rigidbody>();
  }
  
}
