using DataModel.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace All
{
    /// <summary>
    /// IAttacheFileRepository 인터페이스로 파일 첨부관리자 관련 API설계
    /// </summary>
    public interface IAttacheFileRepository
    {
        //입력
        void Add(AttacheFileModel model);

        //출력 : 메서드 오버로드 -> 매개변수 사용해도 됨
        //List<AttacheFileModel> GetAll();
        List<AttacheFileModel> GetAll(int pageNumber = 1, int pageSize = 10);

        //상세
        List<AttacheFileModel> GetByBoardAndArticle(int boardId, int articleId);
        List<AttacheFileModel> GetById(int id);

        //수정
        void UpdateById(string fileName, int fileSize, int id);
        void UpdateDownCountById(int id);

        //삭제
        void RemoveById(int id);

        //검색
        List<AttacheFileModel> GetByFileName(string fileName);
    }
}
