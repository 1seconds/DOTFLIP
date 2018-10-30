using UnityEngine;
using System.Collections;

public class updateMemo : MonoBehaviour {

    /*
	 * 
	 * 
	 
	 28, 20, 16신 
	코스모스 -  태그 삭제함 untag (기존 Obstacle)
	총알 - 태그 삭제 untag ( 기존 Obstacle)

	bullet 스크립트{
		rigibody 추가
		obstacle tag 충돌하면 Active false
	}

	kernel 스크립트 {
		Dong(ReadyBall 상태)만 이동 가능하게 고침 (기존 object 다가능 )
	}

	  
	*/

    //10.11 by 유성현
    //blink 스크립트 수정 - 두더지 이미지 씌워지면서 애니메이션이아닌 스크립트로 처리
    //ObstacleScript에서 다른 장애물에 부딪혀 파괴되면 블럭 오브젝트도 같이 파괴되는 문제가잇어서 스크립트수정
    //blinkScript 스크립트 수정 - 스위치 잇는 스크립트도 두더지 이미지 씌워지면서 같이수정
    // --> 25스테이지 버튼 체크후 두더지에 맞았을때 두더지가 계속 튀어나옴. 버그수정해야함.
    //posInfoScript 스크립트 수정 - UI가 이제 -1로 위치해야하므로 Vector2 -> Vector3 z값을 -1로 고정
    //카메라 Projection Perspective -> Orthographic 으로 변경 후 size 5.75로 조정
    //component inactive script 삭제

    //kernel tag untag (기존 Obstacle) 10.12 by inhoi

    //10.12 by 유성현
    //blink 스크립트 수정 - bool타입 public으로 둬서 두더지가 위에서 아래로 깜빡거릴지, 아래에서 위로 깜빡거릴지 판단
    // --> 예제 : 19스테이지 ,5스테이지
    //Quit스크립트 수정 --> UI작업시 확인창 출력
    //ExitConfirm 스크립트 생성 -- 시작화면에서 종료 / 확인창 display
    //InGameManager 스크립트 생성 -- 인게임상에 설정 / 사운드 / 종료 / 휴지통
    //click event에서 종료하는거 InGameManager로 이동
    //freeze스크립트 삭제

    //10.13 by 유성현
    //InGameManager 스크립트 수정
    //OutOfCamera 스크립트 수정
    //ClickEvent 스크립트 수정
    //back 스크립트 삭제
    //stageClearScript 수정
    //PosInfoObject와 PosInfoScript는 PosManager오브젝트가 없어짐에따라 안쓰이게 되었습니다.
    //--> 혹시몰라서 스크립트는 삭제하지 않겠습니다.

    //00씬에 카메라와 캔버스 오디오매니져가 있고 나머지 씬은 존재하지않습니다.
    //만약 00씬을거쳐서 테스트하는게 번거롭다면 
    // --> MainCamera를 만들고 태그는 untagged로 변경한후, orthographic으로 변경후
    // --> 사이즈를 5.75로 변경하고 현재 메인카메라에 붙어있는 컴포넌트들을 붙여서 태스트하시면 됩니다. 
    // --> 아니면 프리팹으로 만들고 Inactive를 시킨다음에 테스트할때마다 키고 테스트하고 끄고 이런식으로 반복할까요 ..?

	//inhoi  10월 17일
	// prefab으로 만들어서 쓰자 ㅋㅋ
	// leaf right go  position.x -> position.y로 수정 
	// 37 stage digda 맞는지???
	// digda 땅에 들어갈 때 코스모스 총알 지나가게 

	/*
	//inhoi 10.20
	ObtacleBtn 스크립트 생성했음
	- 34스테이지에서 
	btn 충돌시 로봇 움직이게 하고
	ClickEvent.isDoClick==false 
	게임에서 패배하면
	원래 위치로 돌려놓는 스크립트
	          40stage 완료 



	*/
}
