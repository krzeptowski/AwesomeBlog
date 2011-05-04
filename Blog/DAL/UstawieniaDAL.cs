using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public interface IUstawienia
    {
        string getSettings(string key);
        bool setSettings(Models.UstawieniaModel model);
        bool addSettins(Models.UstawieniaModel model);

        bool existSettings(string key);
    }

    public class UstawieniaServices : IUstawienia
    {
        IUstawienia _ustawienia;
        
        public UstawieniaServices() 
        { 
            _ustawienia = new UstawieniaDAL(); 
        }

        public string getSettings(string key)
        {
            #region walidacja
            if (String.IsNullOrEmpty(key)) throw new ArgumentException("Klucz nie może być pusty", key);
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Klucz nie może zawierać białych znaków", key);
            if (!existSettings(key)) throw new ArgumentException("Podany klucz: "+key+" nie istnieje", key);
            #endregion

            return _ustawienia.getSettings(key);
        }
        public bool setSettings(Models.UstawieniaModel model)
        {
            #region walidacja
            if (String.IsNullOrEmpty(model.key)) throw new ArgumentException("Klucz nie może być pusty", model.key);
            if (String.IsNullOrWhiteSpace(model.key)) throw new ArgumentException("Klucz nie może zawierać białych znaków", model.key);
            if (!existSettings(model.key)) throw new ArgumentException("Podany klucz: " + model.key + " nie istnieje", model.key);

            if (String.IsNullOrEmpty(model.value)) throw new ArgumentException("Wartość nie może być pusta", model.value);
            #endregion

            throw new NotImplementedException();
        }
        public bool addSettins(Models.UstawieniaModel model)
        {
            #region walidacja
            if (String.IsNullOrEmpty(model.key)) throw new ArgumentException("Klucz nie może być pusty", model.key);
            if (String.IsNullOrWhiteSpace(model.key)) throw new ArgumentException("Klucz nie może zawierać białych znaków", model.key);
            if (existSettings(model.key)) throw new ArgumentException("Podany klucz: " + model.key + " już istnieje", model.key);

            if (String.IsNullOrEmpty(model.value)) throw new ArgumentException("Wartość nie może być pusta", model.value);
            #endregion

            throw new NotImplementedException();
        }

        public bool existSettings(string key)
        {
            #region walidacja
            /* wcześniej już to sprawdziłem przed wywołaniem - prywatna wieć nie wywoła się nigdzie indziej
             if (String.IsNullOrEmpty(key)) throw new ArgumentException("Klucz nie może być pusty", key);
             if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Klucz nie może zawierać białych znaków", key);
             */
            #endregion

            return _ustawienia.existSettings(key);
        }
    }

    public class UstawieniaDAL:IUstawienia
    {
        public string getSettings(string key)
        {
            using (LinqTodbBlogDataContext db = new LinqTodbBlogDataContext())
            {
                try
                {
                    return (from k in db.Ustawienias where k.key == key select k.value).Single();
                }
                catch (Exception e)
                { throw new Exception(e.Message.ToString(), e); }
            }
        }
        public bool setSettings(Models.UstawieniaModel model)
        {
            throw new NotImplementedException();
        }
        public bool addSettins(Models.UstawieniaModel model)
        {
            throw new NotImplementedException();
        }


        public bool existSettings(string key)
        {
            using (LinqTodbBlogDataContext db = new LinqTodbBlogDataContext())
            {
                try
                {
                    return (from k in db.Ustawienias where k.key == key select k).Any();
                }
                catch (Exception e)
                { throw new Exception(e.Message.ToString(), e); }
            }
        }
    }
}