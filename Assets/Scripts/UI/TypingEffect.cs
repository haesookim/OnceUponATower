using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
	public Text tx;
	public float typeVelocity = 0.03f;
	private string sText = @"옛날 옛적 어느 낡은 성에는 욕심 많은 드래곤이 살고 있었어요.
드래곤은 끊임없이 재물과 보석을 모았지만, 언제나 부족함을 느꼈어요.

그러던 어느 날, 드래곤은 결국 이웃나라 공주님을 납치하고 말아요.
탑에 갇힌 공주님은 자신을 구하러 올 왕자님을 하염없이 기다렸어요.

하루가 지나고… 이틀이 지나고…
탑에 갇힌 지 14일째 되던 날, 공주님은 뭔가 단단히 잘못되었음을 깨닫기 시작해요.


																														Click >>
";
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(typeEffect());
	}
	IEnumerator typeEffect()
	{

		for (int i = 0; i <= sText.Length; i++)
		{
			tx.text = sText.Substring(0, i);
			yield return new WaitForSeconds(typeVelocity);
		}

	}

}
