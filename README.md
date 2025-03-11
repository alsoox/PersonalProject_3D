 Unity 3D 입문 개인 프로젝트  
 스파르타코딩클럽에서 주어진 필수 및 도전 기능 진행
 ## 게임 시연 영상  
 [![Video Label](http://img.youtube.com/vi/oEWwYGMXtw4/0.jpg)](https://youtu.be/oEWwYGMXtw4)
 
 ## 🔨필수 기능 구현 
 ### 1. 기본 이동 및 점프
 #### * InputSystem 이용
   + 플레이어이동 (W, A, S, D)
   + 시선처리 (Mouse)
   + 점프 (Space) - 방패 착용시 더블점프 가능
   + 인벤토리 (Tab)
   + 아이템획득 (E)
   + 기본 대쉬 (Shift) - 스테미나사용
   + 스킬 대쉬 (Q) - 검 착용시 사용 가능

![image](https://github.com/user-attachments/assets/8b0c4961-197c-45d6-aae8-8c65a3297bd7)

 ### 2. 체력바 UI 
 #### * 플레이어 체력에 따라 UI 갱신
 
 ![image](https://github.com/user-attachments/assets/7f519d8d-256d-4638-9447-9aa05f6af7a6)

 ### 3. 동적 환경 조사
 #### * 플레이어 체력에 따라 UI 갱신 
   + 플레이어 체력에 따라 UIBar 변화  
   + RayCast 를 이용하여 구현
     
![image](https://github.com/user-attachments/assets/64c4c51f-43ca-441e-86de-8446598fdd30)

 ### 4. 점프대
 #### * 캐릭터가 JumpPlane 밟을 시 높이 뛰어 오름
   + OnCollision 및 ForceMode.Inpulse 이용

https://github.com/user-attachments/assets/4ccd2037-b6a1-4b70-9b24-cf15386e9e23

 ### 5. 아이템 데이터
 #### * SriptableObject 사용
   + Eat : 아이템 섭취 (획득 X, Trigger)
   + Consume : 소비용 아이템 ( 다수 획득 O )
   + Equip : 장착용 아이템 ( 1개만 획득 O, 착용시 스킬 사용 가능)
 
![image](https://github.com/user-attachments/assets/163503ca-f19b-48a6-a98a-59aaa18279d7)  
![image](https://github.com/user-attachments/assets/c92bf2cb-7fb2-4ec6-954f-f8cc8713a7f5)

 ### 6. 아이템 사용
 #### * PlayerCondition & ItemData & Inventory 사용
   + 소비용 아이템
   + 햄버거 : 체력 회복
   + 음료수 : 스테미나 회복
     
![image](https://github.com/user-attachments/assets/16436440-145d-40bd-9145-19bf701495b5)
  
  

## ⚒️도전 기능 구현 
 ### 1. 추가 UI
 #### * 스태미나 UI
   + 기본 대쉬 (Sfhit) 이용 시 스태미나 감소 ( 시간이 지남에 따라 스태미나도 서서히 증가 )  
![image](https://github.com/user-attachments/assets/d3c4aa2f-996c-44b1-ae7e-91fee8e46f04)

#### * 인벤토리 UI
   + Equip : 획득 장비 및 장착 여부 확인 가능
   + Consum : 획득 소비아이템 남은 수량 확인 가능
   + Apple : 획득 사과 확인 가능
   + Info : 아이템 선택 시 설명
   + Equip/Eat : 장비 장착 및 소비아이템 사용 버튼  
![image](https://github.com/user-attachments/assets/bfd90e2a-7852-4316-a421-bbc430bb30b7)

#### * 스킬 쿨타임 UI
   + ImageType / fillAmount 사용
   
https://github.com/user-attachments/assets/514be3d6-3fd5-44bf-9bd5-14770089331e

### 2. 3인칭 시점
 #### * Player 뒤쪽에 MainCamera 위치 및 마우스 Delta 값 카메라에 적용
![image](https://github.com/user-attachments/assets/646fe4ee-dfc0-4ac1-a041-1c46073b053c)

### 3. 움직이는 플랫폼 구현
 + prevPos / desiredPos 확인 후 Plane 이동
 + Collision 으로 Layer 확인 후 Player 를 Plane 자식으로 이동 시켜 움직이 같이 일어나도록 구현 

https://github.com/user-attachments/assets/1e5653ce-43a3-4d44-9c67-6e4d9bf9cfee

### 4. 다양한 아이템 구현 & 장비장착
#### 섭취용 / 소비용 / 장착용 아이템
 
![image](https://github.com/user-attachments/assets/e2b7b111-89d6-4d17-954c-37febdd7da23)

#### * 섭취용  
   + 사과 : 코인
   + 케이크 : 체력 소량 회복
   + 독버섯 : 체력 감소  
#### * 소비용  
   + 햄버거 : 체력 대량 회복
   + 음료수 : 스테미나 대량 회복
#### * 장착용 (스킬사용가능)
   + 검 : 스킬 대쉬( Q ) 사용 가능
   + 방패 : 더블 점프 가능


https://github.com/user-attachments/assets/64cdc0f4-42e5-4892-bd9f-668d01d5237e

