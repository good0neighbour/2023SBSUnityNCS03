#pragma once
//include guard

//�θ�Ŭ����

class CUnit
{
//private:
protected:  //Ŭ���� ��� ���� ���� �ȿ��� ���� ����
    float mHP = 0.0f;
    float mAP = 0.0f;

public:
    inline const float GetHP() const
    {
        return mHP;
    }

    inline const float GetAP() const
    {
        return mAP;
    }

    //override + virtual
    //�θ� Ŭ������ ������ Ÿ������ �ڽ�Ŭ���� Ÿ���� ��ü���� �ٷ� �� �ִ�.
    virtual void DoDamage(CUnit* tAttacker) {};
};

