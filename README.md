# blabla car-like web api

  net 6.0 yüklü olmalıdır.  !!!
  dataları postman aracılığıyla ekleyebilirsiniz. 

  4 tane endpoint bulunmaktadır.

  [HttpPost("AddTravel")]
  //Kullanıcı sisteme seyahat planını Nereden, Nereye, Tarih ve Açıklama, Koltuk Sayısı bilgilerini ekleyebilir.
  
  [HttpGet("GetAll")]
  public List<Travel> GetAll([FromQuery] String arrival, String destination)
  //Kullanıcılar sistemdeki yayında olan seyahat planlarını Nereden ve Nereye bilgileri ile aratabilir.

  
  [HttpPut("ChangePublishState")]
  public bool ChangePublishState([FromQuery] int id)
  //Kullanıcı tanımladığı seyahat planını yayına alabilir ve yayından kaldırabilir.

  [HttpPut("AddPassengerToTravel")]
  public ActionResult<bool> AddPassengerToTravel([FromQuery] int passengerCount, int travelId)
  Kullanıcılar yayında olan seyehat planlarına "Koltuk Sayısı" dolana kadar katılım isteği gönderebilir.

