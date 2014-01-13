#pragma strict
var speed : float = 5;
var anim : Animator;
function Start () {
	
	anim = gameObject.GetComponent(Animator);
}

function Update () {
	anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
	transform.position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
}