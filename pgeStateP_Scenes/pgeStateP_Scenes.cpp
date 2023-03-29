#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

//step_0
//enum SCENE
//{
//	TITLE = 0,
//	READY_PLAYGAME,
//	PLAYGAME,
//	END
//};
//
//// Override base class with your custom functionality
//class Example : public olc::PixelGameEngine
//{
//	//타이틀 장면으로 시작하려고 함
//	SCENE mStateScene = SCENE::TITLE;
//
//
//public:
//	Example()
//	{
//		// Name your application
//		sAppName = "Example";
//	}
//
//public:
//	bool OnUserCreate() override
//	{
//		//타이틀 장면으로 시작하려고 함
//		mStateScene = SCENE::TITLE;
//
//
//		// Called once at the start, so create things here
//		return true;
//	}
//
//	bool OnUserUpdate(float fElapsedTime) override
//	{
//		
//		switch (mStateScene)
//		{
//		case SCENE::TITLE:
//		{
//			Clear(olc::VERY_DARK_BLUE);
//			DrawString(100, 100, "TITLE");
//
//			if (GetKey(olc::SPACE).bReleased)
//			{
//				mStateScene = SCENE::READY_PLAYGAME;
//			}
//		}
//		break;
//		case SCENE::READY_PLAYGAME:
//		{
//			Clear(olc::BLACK);
//			DrawString(100, 100, "READY_PLAYGAME");
//
//			if (GetKey(olc::SPACE).bReleased)
//			{
//				mStateScene = SCENE::PLAYGAME;
//			}
//		}
//		break;
//		case SCENE::PLAYGAME:
//		{
//			Clear(olc::DARK_RED);
//			DrawString(100, 100, "PLAYGAME");
//
//			if (GetKey(olc::SPACE).bReleased)
//			{
//				mStateScene = SCENE::END;
//			}
//		}
//		break;
//		case SCENE::END:
//		{
//			Clear(olc::VERY_DARK_GREY);
//			DrawString(100, 100, "END");
//
//			if (GetKey(olc::SPACE).bReleased)
//			{
//				mStateScene = SCENE::TITLE;
//			}
//		}
//		break;
//		}
//
//		return true;
//	}
//};





//step_1
//enum SCENE
//{
//	TITLE = 0,
//	READY_PLAYGAME,
//	PLAYGAME,
//	END
//};
//
//// Override base class with your custom functionality
//class Example : public olc::PixelGameEngine
//{
//	//타이틀 장면으로 시작하려고 함
//	SCENE mStateScene = SCENE::TITLE;
//
//
//public:
//	Example()
//	{
//		// Name your application
//		sAppName = "Example";
//	}
//
//public:
//	bool OnUserCreate() override
//	{
//		//타이틀 장면으로 시작하려고 함
//		mStateScene = SCENE::TITLE;
//
//
//		// Called once at the start, so create things here
//		return true;
//	}
//
//	bool OnUserUpdate(float fElapsedTime) override
//	{
//		//enum과 switch구문을 결함하여 작성한 장면구조관리코드다.
//		//원한다면 이것은 멤버함수의 참조 테이블 형태로 수정가능하다.
//		switch (mStateScene)
//		{
//		case SCENE::TITLE:
//		{
//			UpdateSceneTitle();
//		}
//		break;
//		case SCENE::READY_PLAYGAME:
//		{
//			UpdateSceneReadyGame();
//		}
//		break;
//		case SCENE::PLAYGAME:
//		{
//			UpdateScenePlayGame();
//		}
//		break;
//		case SCENE::END:
//		{
//			UpdateSceneEnd();
//		}
//		break;
//		}
//
//		return true;
//	}
//	void UpdateSceneEnd()
//	{
//		Clear(olc::VERY_DARK_GREY);
//		DrawString(100, 100, "END");
//
//		if (GetKey(olc::SPACE).bReleased)
//		{
//			mStateScene = SCENE::TITLE;
//		}
//	}
//	void UpdateScenePlayGame()
//	{
//		Clear(olc::DARK_RED);
//		DrawString(100, 100, "PLAYGAME");
//
//		if (GetKey(olc::SPACE).bReleased)
//		{
//			mStateScene = SCENE::END;
//		}
//	}
//	void UpdateSceneReadyGame()
//	{
//		Clear(olc::BLACK);
//		DrawString(100, 100, "READY_PLAYGAME");
//
//		if (GetKey(olc::SPACE).bReleased)
//		{
//			mStateScene = SCENE::PLAYGAME;
//		}
//	}
//	void UpdateSceneTitle()
//	{
//		Clear(olc::VERY_DARK_BLUE);
//		DrawString(100, 100, "TITLE");
//
//		if (GetKey(olc::SPACE).bReleased)
//		{
//			mStateScene = SCENE::READY_PLAYGAME;
//		}
//	}
//};

//step_2
// 각각의 장면에 관한 코드를 클래스화해보자.
// ( 상태패턴으로 가기 위해 중간단계 코드를 작성해본다 )
//enum SCENE
//{
//	TITLE = 0,
//	READY_PLAYGAME,
//	PLAYGAME,
//	END
//};
//
////추상 클래스 abstract class
//class CScene
//{
//public:
//	virtual void Update(olc::PixelGameEngine* tpEngine) = 0;	//순수 가상 함수
//	//함수의 형태만 제공한다.
//};
//
//class CSceneTitle : public CScene
//{
//public:
//	virtual void Update(olc::PixelGameEngine* tpEngine) override;
//};
//class CSceneReadyPlayGame : public CScene
//{
//public:
//	virtual void Update(olc::PixelGameEngine* tpEngine) override;
//};
//class CScenePlayGame : public CScene
//{
//public:
//	virtual void Update(olc::PixelGameEngine* tpEngine) override;
//};
//class CSceneEnd : public CScene
//{
//public:
//	virtual void Update(olc::PixelGameEngine* tpEngine) override;
//};
//
//
//
//// Override base class with your custom functionality
//class Example : public olc::PixelGameEngine
//{
//public:
//	//타이틀 장면으로 시작하려고 함
//	SCENE mStateScene = SCENE::TITLE;
//
//	//현재 장면 참조 객체
//	CScene* mpScene = nullptr;
//
//
//public:
//	Example()
//	{
//		// Name your application
//		sAppName = "Example";
//	}
//
//public:
//	bool OnUserCreate() override
//	{
//		//타이틀 장면으로 시작하려고 함
//		mStateScene = SCENE::TITLE;
//
//
//		// Called once at the start, so create things here
//		return true;
//	}
//
//	bool OnUserUpdate(float fElapsedTime) override
//	{
//
//		if (nullptr == mpScene)
//		{
//			//mpScene이 널이라면, 상황에 맞는 타입의 객체(임의의 장면 객체)를 만든다
//
//			switch (mStateScene)
//			{
//			case SCENE::TITLE:
//			{
//				mpScene = new CSceneTitle();
//			}
//			break;
//			case SCENE::READY_PLAYGAME:
//			{
//				mpScene = new CSceneReadyPlayGame();
//			}
//			break;
//			case SCENE::PLAYGAME:
//			{
//				mpScene = new CScenePlayGame();
//			}
//			break;
//			case SCENE::END:
//			{
//				mpScene = new CSceneEnd();
//			}
//			break;
//			}
//		}
//		else
//		{
//			//결정된 장면객체를 update한다
//			mpScene->Update(this);
//		}
//
//		return true;
//	}
//
//
//
//};
//
//
//
//
//void CSceneTitle::Update(olc::PixelGameEngine* tpEngine)
//{
//	tpEngine->Clear(olc::VERY_DARK_BLUE);
//	tpEngine->DrawString(100, 100, "TITLE");
//
//	if (tpEngine->GetKey(olc::SPACE).bReleased)
//	{
//		((Example*)tpEngine)->mStateScene = SCENE::READY_PLAYGAME;
//
//
//		delete this;
//		((Example*)tpEngine)->mpScene = nullptr;
//	}
//}
//
//void CSceneReadyPlayGame::Update(olc::PixelGameEngine* tpEngine)
//{
//	tpEngine->Clear(olc::BLACK);
//	tpEngine->DrawString(100, 100, "READY_PLAYGAME");
//
//	if (tpEngine->GetKey(olc::SPACE).bReleased)
//	{
//		((Example*)tpEngine)->mStateScene = SCENE::PLAYGAME;
//
//		delete this;
//		((Example*)tpEngine)->mpScene = nullptr;
//	}
//}
//
//void CScenePlayGame::Update(olc::PixelGameEngine* tpEngine)
//{
//	tpEngine->Clear(olc::DARK_RED);
//	tpEngine->DrawString(100, 100, "PLAYGAME");
//
//	if (tpEngine->GetKey(olc::SPACE).bReleased)
//	{
//		((Example*)tpEngine)->mStateScene = SCENE::END;
//
//		delete this;
//		((Example*)tpEngine)->mpScene = nullptr;
//	}
//}
//
//void CSceneEnd::Update(olc::PixelGameEngine* tpEngine)
//{
//	tpEngine->Clear(olc::VERY_DARK_GREY);
//	tpEngine->DrawString(100, 100, "END");
//
//	if (tpEngine->GetKey(olc::SPACE).bReleased)
//	{
//		((Example*)tpEngine)->mStateScene = SCENE::TITLE;
//
//		delete this;
//		((Example*)tpEngine)->mpScene = nullptr;
//	}
//}




//step_3
// 상태 패턴 state pattern을 적용하자
// State Pattern : 상태와 그에 대응되는 '행위'를 객체로 캡슐화하여
//객체 단위로 처리하는 것을 목적으로 하는 디자인 패턴


//추상 클래스 abstract class
class CScene
{
public:
	virtual void Update(olc::PixelGameEngine* tpEngine) = 0;	//순수 가상 함수
	//함수의 형태만 제공한다.
	virtual CScene* HandleInput(olc::PixelGameEngine* tpEngine) = 0;
};

class CSceneTitle : public CScene
{
public:
	virtual void Update(olc::PixelGameEngine* tpEngine) override;
	virtual CScene* HandleInput(olc::PixelGameEngine* tpEngine) override;
};
class CSceneReadyPlayGame : public CScene
{
public:
	virtual void Update(olc::PixelGameEngine* tpEngine) override;
	virtual CScene* HandleInput(olc::PixelGameEngine* tpEngine) override;
};
class CScenePlayGame : public CScene
{
public:
	virtual void Update(olc::PixelGameEngine* tpEngine) override;
	virtual CScene* HandleInput(olc::PixelGameEngine* tpEngine) override;
};
class CSceneEnd : public CScene
{
public:
	virtual void Update(olc::PixelGameEngine* tpEngine) override;
	virtual CScene* HandleInput(olc::PixelGameEngine* tpEngine) override;
};



// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
public:

	//현재 장면 참조 객체
	CScene* mpScene = nullptr;


public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		mpScene = new CSceneTitle();

		// Called once at the start, so create things here
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		//호출하는 측의 코드는 이제 변경이 필요없다.
		//호출하는 측은 실제 구체적인 클래스를 몰라도 된다.
		//즉, 추상클래스를 통해 약하게 결합되어 있는 것이다.
		//쪼한
		//각각의 상태별 구체적인 클래스도 추상 클래스를 상속받으므로 약하게 결합되어 있는 것이다
		//그러므로 유연한 구조다.
		//
		//예를 들면, 임의의 상태를 추가하고 싶다면, 해당 클래스만 작성하여 빌드하면 된다
		CScene* tpScene = nullptr;

		tpScene = mpScene->HandleInput(this);

		if (nullptr != tpScene)
		{
			delete mpScene;
			mpScene = tpScene;
		}
		
		//결정된 장면객체를 update한다
		mpScene->Update(this);
		

		return true;
	}



};




void CSceneTitle::Update(olc::PixelGameEngine* tpEngine)
{
	tpEngine->Clear(olc::VERY_DARK_BLUE);
	tpEngine->DrawString(100, 100, "TITLE");
}
CScene* CSceneTitle::HandleInput(olc::PixelGameEngine* tpEngine)
{
	if (tpEngine->GetKey(olc::SPACE).bReleased)
	{
		return new CSceneReadyPlayGame();
	}

	return nullptr;
}

void CSceneReadyPlayGame::Update(olc::PixelGameEngine* tpEngine)
{
	tpEngine->Clear(olc::BLACK);
	tpEngine->DrawString(100, 100, "READY_PLAYGAME");
}

CScene* CSceneReadyPlayGame::HandleInput(olc::PixelGameEngine* tpEngine)
{
	if (tpEngine->GetKey(olc::SPACE).bReleased)
	{
		return new CScenePlayGame();
	}

	return nullptr;
}

void CScenePlayGame::Update(olc::PixelGameEngine* tpEngine)
{
	tpEngine->Clear(olc::DARK_RED);
	tpEngine->DrawString(100, 100, "PLAYGAME");
}

CScene* CScenePlayGame::HandleInput(olc::PixelGameEngine* tpEngine)
{
	if (tpEngine->GetKey(olc::SPACE).bReleased)
	{
		return new CSceneEnd();
	}

	return nullptr;
}

void CSceneEnd::Update(olc::PixelGameEngine* tpEngine)
{
	tpEngine->Clear(olc::VERY_DARK_GREY);
	tpEngine->DrawString(100, 100, "END");
}

CScene* CSceneEnd::HandleInput(olc::PixelGameEngine* tpEngine)
{
	if (tpEngine->GetKey(olc::SPACE).bReleased)
	{
		return new CSceneTitle();
	}

	return nullptr;
}


int main()
{
	Example demo;
	if (demo.Construct(256, 240, 2, 2))
		demo.Start();
	return 0;
}